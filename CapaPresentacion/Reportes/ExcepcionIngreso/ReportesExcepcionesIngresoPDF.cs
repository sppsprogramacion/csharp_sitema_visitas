using CapaDatos;
using CommonCache;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace CapaPresentacion.Reportes.ExcepcionIngreso
{
    public class ReportesExcepcionesIngresoPDF
    {
        //VINCULOS DE LA VISITA         
        public static MemoryStream RepPdfExcepcionesIngreso(List<DExcepcionIngresoVisita> listaExcepciones)
        {
            MemoryStream ms = new MemoryStream();

            Document doc = new Document(PageSize.A4.Rotate(), 30, 30, 30, 30);

            PdfWriter writer = PdfWriter.GetInstance(doc, ms);
            writer.CloseStream = false; // evita cerrar el MemoryStream al cerrar el documento

            doc.Open();

            var fuenteLogo = FontFactory.GetFont(FontFactory.TIMES, 9, BaseColor.BLACK);
            var fuenteOrganismo = FontFactory.GetFont(FontFactory.TIMES, 10, BaseColor.BLACK);
            var fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11, BaseColor.BLACK);
            var fuenteNormal = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.BLACK);
            var fuenteTabla = FontFactory.GetFont(FontFactory.HELVETICA, 8, BaseColor.BLACK);

            //logo encabezado
            // Cargar directamente desde Resources
            System.Drawing.Image logoImg = Properties.Resources.logo_spps2;
            // Convertir a iTextSharp Image
            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(logoImg, System.Drawing.Imaging.ImageFormat.Png);
            string organismo = CurrentUser.Instance.organismo.ToUpper();
            logo.ScaleAbsolute(30, 40);
            logo.SetAbsolutePosition(150, 540);
            doc.Add(logo);

            doc.Add(new Paragraph(" "));

            // Crear tabla con 2 columnas
            PdfPTable tablaEncabezado = new PdfPTable(1);
            tablaEncabezado.WidthPercentage = 35; // ocupa la mitad de la página
            tablaEncabezado.HorizontalAlignment = Element.ALIGN_LEFT; // tabla a la izquierda

            // Centrar contenido de todas las celdas
            tablaEncabezado.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tablaEncabezado.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            tablaEncabezado.DefaultCell.Border = Rectangle.NO_BORDER;

            // Agregar celdas
            tablaEncabezado.AddCell(new Paragraph("  SERVICIO PENITENCIARIO DE LA PROVINCIA DE SALTA", fuenteLogo));
            tablaEncabezado.AddCell(new Paragraph(organismo, fuenteOrganismo));

            // Agregar tabla al documento
            doc.Add(tablaEncabezado);
            //fin logo encabezado.....................................

            //fecha
            DateTime fechaHoy = DateTime.Now;
            CultureInfo cultura = new CultureInfo("es-ES");

            // "d 'de' MMMM 'de' yyyy" → ejemplo: "9 de septiembre de 2025"
            string fechaCompleta = "Salta, " + fechaHoy.ToString("d 'de' MMMM 'de' yyyy", cultura);

            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph(fechaCompleta, fuenteNormal)
            {
                Alignment = Element.ALIGN_RIGHT
            });
            //fin fecha.............................

            doc.Add(new Paragraph(" "));


            Paragraph titulo = new Paragraph("Excepciones de ingreso", fuenteTitulo);
            titulo.Alignment = Element.ALIGN_CENTER;
            doc.Add(titulo);


            doc.Add(new Paragraph(" "));

            PdfPTable tablaVinculos = new PdfPTable(4);
            tablaVinculos.WidthPercentage = 100;
            tablaVinculos.SetWidths(new float[] { 1.4f, 1.4f,0.5f, 3.7f });
            tablaVinculos.AddCell(new Paragraph("Interno", fuenteNormal));
            tablaVinculos.AddCell(new Paragraph("Visita", fuenteNormal));
            tablaVinculos.AddCell(new Paragraph("Fecha", fuenteNormal));
            tablaVinculos.AddCell(new Paragraph("Detalle", fuenteNormal));

            // Filas dinámicas
            foreach (var excepcion in listaExcepciones)
            {
                tablaVinculos.AddCell(new Paragraph(excepcion.interno.apellido.ToString() + " " + excepcion.interno.nombre.ToString(), fuenteTabla));
                tablaVinculos.AddCell(new Paragraph(excepcion.ciudadano.apellido + " " + excepcion.ciudadano.nombre, fuenteTabla));
                tablaVinculos.AddCell(new Paragraph(excepcion.fecha_excepcion.ToShortDateString(), fuenteTabla));
                tablaVinculos.AddCell(new Paragraph(excepcion.motivo.ToString() + " - " + excepcion.detalle_excepcion.ToString(), fuenteTabla));
            }

            doc.Add(tablaVinculos);

            doc.Close(); // Cierra el documento pero NO el MemoryStream
            ms.Position = 0;

            return ms;
        }

    }
}
