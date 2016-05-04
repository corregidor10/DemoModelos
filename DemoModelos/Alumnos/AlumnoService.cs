using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using Microsoft.BusinessData.Infrastructure.SecureStore;
using Microsoft.BusinessData.MetadataModel;
using Microsoft.BusinessData.Runtime;
using Microsoft.BusinessData.SystemSpecific;
using Microsoft.Office.SecureStoreService.Server;
using Microsoft.SharePoint;

namespace DemoModelos.Alumnos
{

    public class AlumnoService : IContextProperty
    {
        public IMethodInstance MethodInstance { get; set; }
        public ILobSystemInstance LobSystemInstance { get; set; }
        public IExecutionContext ExecutionContext { get; set; }




        public static void GetCredenciales(out string user, out string pwd)
        {

            user = "";
            pwd = "";

            var appId = "Alumnos";

            ISecureStoreProvider provider = SecureStoreProviderFactory.Create();

            ISecureStoreServiceContext providerContext = provider as ISecureStoreServiceContext;

            providerContext.Context = SPServiceContext.GetContext(new SPSite("http://pruebassp2"));

            using (var creds = provider.GetCredentials(appId))
            {
                if (creds != null)
                {
                    foreach (var cr in creds)
                    {

                        if (cr.CredentialType == SecureStoreCredentialType.UserName)
                        {
                            user = GetCredentialFromString(cr.Credential);
                        }
                        else if (cr.CredentialType == SecureStoreCredentialType.Password)
                        {
                            pwd = GetCredentialFromString(cr.Credential);

                        }

                    }
                }
            }
        }

         
        private static string GetCredentialFromString(SecureString credentials)
        {
            if (credentials == null)
            {
                return null;
            }
            // un puntero es una reserva de memoria 
            IntPtr texto = IntPtr.Zero;

            // A través del marshalling accedemos a librerías internas del sistema y le pedimos que nos deje el espacio en memoria y al final lo liberamos

            try
            {
                texto = Marshal.SecureStringToBSTR(credentials);

                return Marshal.PtrToStringBSTR(texto);
            }

            finally
            {
                if (texto!=IntPtr.Zero)
                {
                    Marshal.FreeBSTR(texto);
                  
                }

            }
        }

        public static Alumno ReadItem(int id)
        {
            string pwd = "";
            string user = "";

            GetCredenciales(out user, out pwd); // TODO. Falta

            Alumno al = new Alumno();
            return al;
        }

        public static IEnumerable<Alumno> ReadList()
        {
            Alumno[] entityList = new Alumno[1];

            Alumno entity1 = new Alumno();
            entity1.Id = 0;

            entityList[0] = entity1;


            return entityList;
        }

    }

    /// <summary>
    /// All the methods for retrieving, updating and deleting data are implemented in this class file.
    /// The samples below show the finder and specific finder method for Entity1.
    /// </summary>
    //public class Entity1Service
    //{
    //    /// <summary>
    //    /// This is a sample specific finder method for Entity1.
    //    /// If you want to delete or rename the method think about changing the xml in the BDC model file as well.
    //    /// </summary>
    //    /// <param name="id"></param>
    //    /// <returns>Entity1</returns>
    //    public static Alumno ReadItem(int id)
    //    {
    //        //TODO: This is just a sample. Replace this simple sample with valid code.
    //        Alumno entity1 = new Alumno();
    //        entity1.Id = id;
    //        entity1.Message = "Hello World";
    //        return entity1;
    //    }
    //    /// <summary>
    //    /// This is a sample finder method for Entity1.
    //    /// If you want to delete or rename the method think about changing the xml in the BDC model file as well.
    //    /// </summary>
    //    /// <returns>IEnumerable of Entities</returns>
    //    public static IEnumerable<Alumno> ReadList()
    //    {
    //        //TODO: This is just a sample. Replace this simple sample with valid code.
    //        Alumno[] entityList = new Alumno[1];
    //        Alumno entity1 = new Alumno();
    //        entity1.Identifier1 = "0";
    //        entity1.Message = "Hello World";
    //        entityList[0] = entity1;
    //        return entityList;
    //    }
    //}

    //public partial class AlumnoService
    //{

    //    public static Alumno ReadItem(int id)
    //    {
    //      Alumno al= new Alumno();
    //        return al;
    //    }

    //    public static IEnumerable<Alumno> ReadList()
    //    {
    //        Alumno[] entityList= new Alumno[1];

    //        Alumno entity1= new Alumno();
    //        entity1.Id = 0;

    //        entityList[0] = entity1;


    //        return entityList;
    //    }
    //}
}
