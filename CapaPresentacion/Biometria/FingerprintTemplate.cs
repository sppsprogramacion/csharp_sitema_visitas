using DPFP.Processing;
using DPFP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CapaPresentacion.Biometria
{
    public class FingerprintTemplate
    {
        // Objeto encargado de construir el template mediante varias muestras.
        private Enrollment enrollment;


        // Inicializa un nuevo proceso de registro.
        public FingerprintTemplate()
        {
            enrollment = new Enrollment();
        }


        // Agrega las características de una muestra al registro.
        public bool AddFeatures(FeatureSet featureSet)
        {
            if (featureSet == null)
                return false;

            try
            {
                enrollment.AddFeatures(featureSet);

                return true;
            }
            catch
            {
                return false;
            }
        }


        // Indica si ya se obtuvieron suficientes muestras.
        public bool IsComplete
        {
            get
            {
                return enrollment.TemplateStatus ==
                       Enrollment.Status.Ready;
            }
        }


        // Devuelve el template generado.
        public Template GetTemplate()
        {
            if (!IsComplete)
                return null;

            return enrollment.Template;
        }


        // Indica cuántas muestras requiere todavía el registro.
        public uint FeaturesNeeded
        {
            get
            {
                return enrollment.FeaturesNeeded;
            }
        }

        // Convierte el Template en un arreglo de bytes.
        public byte[] GetTemplateBytes()
        {
            if (!IsComplete)
                return null;

            Template template = enrollment.Template;

            using (MemoryStream stream = new MemoryStream())
            {
                template.Serialize(stream);

                return stream.ToArray();
            }
        }

        // Reconstruye un Template a partir de los bytes almacenados.
        public Template LoadTemplate(byte[] templateBytes)
        {
            if (templateBytes == null || templateBytes.Length == 0)
                return null;

            Template template = new Template();

            using (MemoryStream stream = new MemoryStream(templateBytes))
            {
                template.DeSerialize(stream);
            }

            return template;
        }
    }
}
