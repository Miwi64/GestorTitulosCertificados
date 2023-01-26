using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoApp.Models
{
    public class DBcrud

    {
        
        public static void AddCertificado(int reg, int folio, string control, string nombre = "", string apat = "", 
              string amat="", string carrera="", DateTime fecha = new DateTime(), string obs="") 
        {
            using (var context = new TitulosCertificadosContext())
            {
                var cert = new Certificado() { RegistroCertificado = reg, Folio = folio, NumeroControl = control };
                context.Certificados.Add(cert);
                context.SaveChanges();
            }
        }
        public static void AddTitulo(int reg, int titulo, string control, int clave = 0,  DateTime fa = new DateTime(), DateTime fr = new DateTime(),  int ced = 0, string obs = "")
        {
            using (var context = new TitulosCertificadosContext())
            {
                var titl = new Titulo() { Registro=reg, TituloLicenciatura=titulo, NumeroControl=control};
                context.Titulos.Add(titl);
                context.SaveChanges();
            }
        }
        public Certificado SearchCertificado(int id)
        {
            using (var context = new TitulosCertificadosContext())
            {
                return context.Certificados.Where(b => b.IdCertificado == id).FirstOrDefault();
            }
        }

        public Titulo SearchTitulo(int id)
        {
            using (var context = new TitulosCertificadosContext())
            {
                return context.Titulos.Where(b => b.IdTitulo == id).FirstOrDefault();
            }
        }

        public List<Certificado> DisplayCertificados()
        {
            using (var context = new TitulosCertificadosContext())
            {
                return context.Certificados.ToList();
            }
        }
        public List<Titulo> DisplayTitulos()
        {
            using (var context = new TitulosCertificadosContext())
            {
                return context.Titulos.ToList();
            }
        }

        public static void DeleteCertificado(int id)
        {
            using (var context = new TitulosCertificadosContext())
            {
                var cert = context.Certificados.FirstOrDefault(c => c.IdCertificado == id);
                if (cert != null) {
                    context.Certificados.Remove(cert);
                    context.SaveChanges();
                }
            }
        }
        public static void DeleteTitulo(int id)
        {
            using (var context = new TitulosCertificadosContext())
            {
                var titl = context.Titulos.FirstOrDefault(c => c.IdTitulo == id);
                if (titl != null)
                {
                    context.Titulos.Remove(titl);
                    context.SaveChanges();
                }
            }
        }
        public static void EditCertificado(int id, int reg, int folio, string control, int clave, string nombre, string apat,
              string amat, string carrera, DateTime fecha, string obs)
        {
            using (var context = new TitulosCertificadosContext())
            {
                var cert = context.Certificados.FirstOrDefault(c => c.IdCertificado == id);
                if (cert != null)
                {
                    cert.RegistroCertificado = reg;
                    cert.Folio = folio;
                    cert.NumeroControl = control;
                    cert.Nombre = nombre;
                    cert.ApellidoPaterno = apat;
                    cert.ApellidoMaterno = amat;
                    cert.Carrera = carrera;
                    cert.FechaRegCert = fecha;
                    cert.Observaciones = obs;

                    context.SaveChanges();
                }
            }
        }
        public static void EditTitulo(int id, int reg, int titulo, string control, DateTime fa, DateTime fr, int ced, string obs)
        {
            using (var context = new TitulosCertificadosContext())
            {
                var titl = context.Titulos.FirstOrDefault(c => c.IdTitulo == id);
                if (titl != null)
                {
                    titl.Registro = reg;
                    titl.TituloLicenciatura = titulo;
                    titl.NumeroControl = control;
                    titl.FechaActo = fa;
                    titl.FechaRegistro = fr;
                    titl.Cedula = ced;
                    titl.Observaciones = obs;

                    context.SaveChanges();
                }
            }
        }
    }
}
