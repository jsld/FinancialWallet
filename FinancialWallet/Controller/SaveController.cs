using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using FinancialWallet.Messages;

namespace FinancialWallet.Controller
{
    public class SaveController
    {
        #region ENTIDAD
        public static ResponseEntity GetLastEntidad()
        {
            var response = new ResponseEntity
            {
                IsValid = true
            };

            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {   
                    response.Entidad = context.EntidadRepositorio.Count() > 0 ?
                        context.EntidadRepositorio.OrderByDescending(x => x.EntidadId)
                        .FirstOrDefault() :
                        null;
                }
            }
            catch(Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public static ResponseEntity GetEntidadByCode(string code)
        {
            var response = new ResponseEntity
            {
                IsValid = true
            };

            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    response.Entidad = context.EntidadRepositorio.Single(x => x.Codigo == code);
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public static ResponseBase CreateEntidad(EntidadRequest request)
        {
            var response = new ResponseBase
            {
                IsValid = true
            };

            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    var entidadExistente = context.EntidadRepositorio
                        .Where(x => x.Codigo == request.EntidadCode ||
                        x.Nombre == request.EntidadNombre).ToList();
                    if (entidadExistente != null || entidadExistente.Any())
                    {
                        response.ErrorMessage = request.EntidadNombre +
                            " ya existe en base de datos.";

                        return response;
                    }

                    var newEntidad = new Entidad
                    {
                        Codigo = request.EntidadCode,
                        Nombre = request.EntidadNombre,
                        TipoId = request.EntidadTipoId
                    };

                    context.EntidadRepositorio.Add(newEntidad);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public static ResponseBase DeleteEntidad(string code)
        {
            var response = new ResponseBase
            {
                IsValid = true
            };

            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    var entidad = context.EntidadRepositorio.Where(x => x.Codigo == code);
                    context.EntidadRepositorio.Remove(entidad.FirstOrDefault());
                    var contacto = context.ContactoRepositorio
                        .Where(x => x.EntidadId == entidad.FirstOrDefault().EntidadId);
                    if (contacto != null)
                    {
                        context.ContactoRepositorio.Remove(contacto.FirstOrDefault());
                    }

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public static ResponseEntity GetAllEntidadesByType(string type)
        {
            var response = new ResponseEntity
            {
                IsValid = true
            };

            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    response.ListaEntidades = (context.EntidadRepositorio
                        .Where(x => x.Tipo.Codigo == type)).ToList();
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }
        #endregion

        #region CONTACTO
        public static ResponseContacto GetContactoByEntityCode(string code)
        {
            var response = new ResponseContacto
            {
                IsValid = true,
                Contacto = null
            };

            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    var result = context.ContactoRepositorio.Where(x => x.Entidad.Codigo == code);
                    if (result != null)
                    {
                        response.Contacto = result.FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public static ResponseBase CreateContacto(
            string telefono,
            string correo,
            string detalle,
            int entidadId)
        {
            var response = new ResponseBase
            {
                IsValid = true
            };

            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    var newContacto = new Contacto
                    {
                        Telefono = Int32.Parse(telefono),
                        Correo = correo,
                        Detalle = detalle,
                        EntidadId = entidadId
                    };

                    context.ContactoRepositorio.Add(newContacto);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public static ResponseBase UpdateContacto(
            string telefono,
            string correo,
            string detalle,
            int entidadId)
        {
            var response = new ResponseBase
            {
                IsValid = true
            };

            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    var result = context.ContactoRepositorio.Where(x => x.EntidadId == entidadId);
                    if (result != null)
                    {
                        var contacto = result.FirstOrDefault();
                        contacto.Correo = correo;
                        contacto.Detalle = detalle;
                        contacto.Telefono = Int32.Parse(telefono);
                    }
                    
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }
        #endregion
    }
}
