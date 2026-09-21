using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPFP.Capture;
using DPFP;
using DPFP.Processing;

namespace CapaPresentacion.Biometria
{
    public class FingerprintProcessor
    {
        // Procesa las muestras obtenidas del lector.
        private FeatureExtraction extractor;


        // Inicializa el procesador.
        public FingerprintProcessor()
        {
            extractor = new FeatureExtraction();
        }


        // Extrae características para REGISTRO.
        public bool ExtractFeaturesForEnrollment(
            Sample sample,
            out FeatureSet featureSet)
        {
            featureSet = new FeatureSet();

            CaptureFeedback feedback = CaptureFeedback.None;

            extractor.CreateFeatureSet( sample, DataPurpose.Enrollment, ref feedback, ref featureSet);

            return feedback == CaptureFeedback.Good;
        }


        // Extrae características para VERIFICACIÓN.
        public bool ExtractFeaturesForVerification(Sample sample,out FeatureSet featureSet)
        {
            featureSet = new FeatureSet();

            CaptureFeedback feedback = CaptureFeedback.None;

            extractor.CreateFeatureSet(
                sample,
                DataPurpose.Verification,
                ref feedback,
                ref featureSet
            );

            return feedback == CaptureFeedback.Good;
        }
    }
}
