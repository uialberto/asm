﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Asm.Aplicacion.Dtos.DataTransfers.Localization {
    using System;
    
    
    /// <summary>
    ///   Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.
    /// </summary>
    // StronglyTypedResourceBuilder generó automáticamente esta clase
    // a través de una herramienta como ResGen o Visual Studio.
    // Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    // con la opción /str o recompile su proyecto de VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class MascotaDto {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal MascotaDto() {
        }
        
        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Asm.Aplicacion.Dtos.DataTransfers.Localization.MascotaDto", typeof(MascotaDto).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        ///   búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Descripción ha superado el número de caracteres permitidos..
        /// </summary>
        public static string DescripcionLengthError {
            get {
                return ResourceManager.GetString("DescripcionLengthError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Dirección ha superado el número de caracteres permitidos..
        /// </summary>
        public static string DireccionLengthError {
            get {
                return ResourceManager.GetString("DireccionLengthError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Color ha superado el tamaño maximo permitido.
        /// </summary>
        public static string KeyColorLengthError {
            get {
                return ResourceManager.GetString("KeyColorLengthError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Estado ha superado el tamaño maximo permitido.
        /// </summary>
        public static string KeyEstadoLengthError {
            get {
                return ResourceManager.GetString("KeyEstadoLengthError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Tamaño ha superado el tamaño maximo permitido..
        /// </summary>
        public static string KeyTamanioLengthError {
            get {
                return ResourceManager.GetString("KeyTamanioLengthError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Tipo animal ha superado el tamaño maximo permitido.
        /// </summary>
        public static string KeyTipoAnimalLengthError {
            get {
                return ResourceManager.GetString("KeyTipoAnimalLengthError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Nombre ha superado el número de caracteres permitidos..
        /// </summary>
        public static string NombreLengthError {
            get {
                return ResourceManager.GetString("NombreLengthError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Raza ha superado el número de caracteres permitidos..
        /// </summary>
        public static string RazaLengthError {
            get {
                return ResourceManager.GetString("RazaLengthError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Raza.
        /// </summary>
        public static string RazaTitulo {
            get {
                return ResourceManager.GetString("RazaTitulo", resourceCulture);
            }
        }
    }
}
