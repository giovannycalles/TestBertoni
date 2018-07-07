using System;
using System.Configuration;
using System.IO;
using System.Web;

namespace Utilities
{
    public class Utility
    {
        public static String DirectorioLog = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["LogDirectory"].ToString());

        /// <summary>
        /// Registra en un archivo TXT los errores arrojados en la aplicación
        /// </summary>
        /// <param name="sClase">string</param>
        /// <param name="sMetodo">string</param>
        /// <param name="sMensaje">string</param>
        /// <param name="sNavegador">string</param>
        /// <param name="sVersion">string</param>
        /// <param name="sProcedimiento">string</param>
        public static void RegistrarExcepcion(string sClase, string sMetodo, string sMensaje, string sNavegador = null, string sVersion = null, string sProcedimiento = null)
        {
            string str = string.Empty;

            if (!File.Exists(HttpContext.Current.Server.MapPath(DirectorioLog)))
            {
                File.Create(HttpContext.Current.Server.MapPath(DirectorioLog)).Close();
            }
            else
            {
                FileInfo fInfo = new FileInfo(DirectorioLog);
                if (fInfo.Length > 10485760)
                {
                    fInfo.MoveTo(DirectorioLog + "_" + DateTime.Now.Day.ToString("D2") + DateTime.Now.Month.ToString("D2") +
                                                       DateTime.Now.Year.ToString("D4") + DateTime.Now.Hour.ToString("D2") +
                                                       DateTime.Now.Minute.ToString("D2") + DateTime.Now.Second.ToString("D2"));
                    File.Delete(DirectorioLog);
                }
                else
                {
                    using (StreamReader sreader = new StreamReader(DirectorioLog))
                    {
                        str = sreader.ReadToEnd();
                    }
                }
            }

            using (StreamWriter writer = new StreamWriter(DirectorioLog, true))
            {
                writer.WriteLine("Fecha: " + DateTime.Now);
                writer.WriteLine("Clase: " + sClase);
                writer.WriteLine("Método: " + sMetodo);
                if (sNavegador != null && sVersion != null)
                {
                    writer.WriteLine("Navegador: " + sNavegador);
                    writer.WriteLine("Version: " + sVersion);
                }
                if (sProcedimiento != null)
                {
                    writer.WriteLine("Procedimiento: " + sProcedimiento);
                }
                writer.WriteLine("ERROR: " + sMensaje);
                writer.WriteLine(Environment.NewLine + "===========================================================================================================================" + Environment.NewLine);
                writer.WriteLine(str);
                writer.Flush();
                writer.Close();
            }


        }

    }
}