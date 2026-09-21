using DPFP.Verification;
using DPFP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion.Biometria
{
    public class FingerprintVerifier
    {

        // Objeto encargado de realizar la comparación 1:1.
        private Verification verifier;

        // Inicializa el verificador.
        public FingerprintVerifier()
        {
            verifier = new Verification();
        }

        // Compara una muestra procesada contra un template.
        public bool Verify(
            FeatureSet features,
            Template template)
        {
            if (features == null || template == null)
                return false;

            Verification.Result result =
                new Verification.Result();

            verifier.Verify(
                features,
                template,
                ref result
            );

            return result.Verified;
        }
    }
}
