using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPFP;
using DPFPCapture = DPFP.Capture;


namespace CapaPresentacion.Biometria
{
    public class FingerprintCapture : IDisposable
    {
        // Objeto principal para controlar el lector.
        private DPFPCapture.Capture capturer;
        // Maneja los eventos generados por el SDK.
        private DPFPCapture.EventHandler captureHandler;

        // Se dispara cuando el lector detecta que se colocó un dedo.
        public event System.EventHandler FingerDetected;
        // Se dispara cuando se retira el dedo del lector.
        public event System.EventHandler FingerRemoved;
        // Se dispara cuando ocurre un error durante la captura.
        public event System.EventHandler<string> CaptureError;
        // Se dispara cuando el lector obtiene una muestra de huella.
        public event System.EventHandler<SampleEventArgs> SampleCaptured;

        // Inicializa el lector y prepara el manejador de eventos.
        public FingerprintCapture()
        {
            capturer = new DPFPCapture.Capture();
            captureHandler = new CaptureHandler(this);
        }

        // Inicia la captura de huellas.
        public void Start()
        {
            if (capturer == null)
                throw new InvalidOperationException(
                    "El lector no está inicializado.");

            try
            {
                // Asigna nuestro manejador de eventos al lector.
                capturer.EventHandler = captureHandler;
                // Comienza a esperar huellas.
                capturer.StartCapture();
            }
            catch (Exception ex)
            {
                // Informa al formulario que ocurrió un error.
                CaptureError?.Invoke(this, ex.Message);
            }
        }

        // Detiene la captura de huellas.
        public void Stop()
        {
            if (capturer != null)
            {
                try
                {
                    capturer.StopCapture();
                }
                catch
                {
                    // No hacemos nada si ya estaba detenido.
                }
            }
        }

        // Notifica que se colocó un dedo en el lector.
        private void FingerTouch(object Capture,string ReaderSerialNumber)
        {
            FingerDetected?.Invoke(
                this,
                System.EventArgs.Empty
            );
        }

        // Notifica que se retiró el dedo del lector.
        private void FingerGone(object Capture,string ReaderSerialNumber)
        {
            FingerRemoved?.Invoke(
                this,
                System.EventArgs.Empty
            );
        }

        // Libera los recursos utilizados por el lector.
        public void Dispose()
        {
            Stop();

            if (capturer != null)
            {
                capturer.Dispose();
                capturer = null;
            }
        }

        // Contiene la muestra de huella capturada.
        public class SampleEventArgs : EventArgs
        {
            public DPFP.Sample Sample { get; private set; }

            public SampleEventArgs(DPFP.Sample sample)
            {
                Sample = sample;
            }
        }

        // Envía la muestra capturada a la aplicación.
        private void SampleComplete(DPFP.Sample sample)
        {
            SampleCaptured?.Invoke(
                this,
                new SampleEventArgs(sample)
            );
        }

        // Clase que recibe los eventos directamente desde DigitalPersona.
        private class CaptureHandler : DPFPCapture.EventHandler
        {
            // Referencia a la clase FingerprintCapture.
            private readonly FingerprintCapture owner;

            // Guarda la referencia a la clase principal.
            public CaptureHandler(FingerprintCapture owner)
            {
                this.owner = owner;
            }

            // Se ejecuta cuando DigitalPersona obtiene una muestra.
            public void OnComplete(object Capture,string ReaderSerialNumber,DPFP.Sample Sample)
            {
                owner.SampleComplete(Sample);
            }

            // Se ejecuta cuando se retira el dedo.
            public void OnFingerGone( object Capture,string ReaderSerialNumber)
            {
                owner.FingerGone(
                    Capture,
                    ReaderSerialNumber
                );
            }

            // Se ejecuta cuando se coloca el dedo.
            public void OnFingerTouch(object Capture,string ReaderSerialNumber)
            {
                owner.FingerTouch(
                    Capture,
                    ReaderSerialNumber
                );
            }

            // Se ejecuta cuando se conecta el lector.
            public void OnReaderConnect( object Capture,string ReaderSerialNumber)
            {
            }

            // Se ejecuta cuando se desconecta el lector.
            public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
            {
            }

            // Informa la calidad de la muestra capturada.
            public void OnSampleQuality( object Capture, string ReaderSerialNumber, DPFP.Capture.CaptureFeedback CaptureFeedback)
            {
            }

        }
    }
}
