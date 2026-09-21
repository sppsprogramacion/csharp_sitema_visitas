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

namespace CapaPresentacion.Reportes.IngresoVisistas
{
    public class ReportesIngresoVisitas
    {
        public static MemoryStream RepPdfFichaIngreso(DEntradaSalidaIngresoPPResponse ingresoPPResponse)
        {
            MemoryStream ms = new MemoryStream();

            //Document doc = new Document(PageSize.A4.Rotate(), 20, 20, 20, 20);
            float mmToPoints = 2.8346457f;
            float anchoPagina = 80f * mmToPoints;
            float altoPagina = 90f * mmToPoints;

            Document doc = new Document(new Rectangle(anchoPagina, altoPagina),
                5f,  // izquierda
                10f,  // derecha
                5f,  // arriba
                5f   // abajo
            );

            PdfWriter writer = PdfWriter.GetInstance(doc, ms);
            writer.CloseStream = false; // evita cerrar el MemoryStream al cerrar el documento

            doc.Open();

            var fuenteLogo = FontFactory.GetFont(FontFactory.TIMES, 7, BaseColor.BLACK);
            var fuenteOrganismo = FontFactory.GetFont(FontFactory.TIMES, 8, BaseColor.BLACK);
            var fuenteFecha = FontFactory.GetFont(FontFactory.TIMES, 10, BaseColor.BLACK);
            var fuenteNumeroFicha = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.BLACK);
            var fuenteVisita = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9, BaseColor.BLACK);
            var fuenteNormal = FontFactory.GetFont(FontFactory.HELVETICA, 9, BaseColor.BLACK);

            // Cargar directamente desde Resources
            System.Drawing.Image logoImg = Properties.Resources.logo_spps2;
            // Convertir a iTextSharp Image
            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(logoImg, System.Drawing.Imaging.ImageFormat.Png);
            logo.ScaleAbsolute(20f, 20f);
            logo.Alignment = Element.ALIGN_CENTER;
            string organismo = CurrentUser.Instance.organismo.ToUpper();
            
            // Crear la celda para logo manualmente
            PdfPCell celdaLogo = new PdfPCell();
            celdaLogo.Border = Rectangle.NO_BORDER;
            celdaLogo.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaLogo.VerticalAlignment = Element.ALIGN_MIDDLE;
            celdaLogo.Padding = 0;
            // Agregar la imagen a la celda
            celdaLogo.AddElement(logo);

            // Crear tabla con 1 columna para el encabezado
            PdfPTable tablaEncabezado = new PdfPTable(1);
            tablaEncabezado.WidthPercentage = 57; // ocupa la mitad de la página
            tablaEncabezado.HorizontalAlignment = Element.ALIGN_LEFT; // tabla a la izquierda

            // Centrar contenido de todas las celdas
            tablaEncabezado.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tablaEncabezado.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            tablaEncabezado.DefaultCell.Border = Rectangle.NO_BORDER;

            // Agregar celdas
            // Imagen
            tablaEncabezado.AddCell(celdaLogo);
            //texto
            tablaEncabezado.AddCell(new Paragraph("SERVICIO PENITENCIARIO \n DE LA PROVINCIA DE SALTA", fuenteLogo)
            {
                Alignment = Element.ALIGN_LEFT
            });

            tablaEncabezado.AddCell(new Paragraph(organismo, fuenteOrganismo));

            // Agregar tabla al documento
            doc.Add(tablaEncabezado);
            //fin logo encabezado.....................................

            //fecha
            doc.Add(new Paragraph(ingresoPPResponse.fecha_registro.ToShortDateString() + " " + ingresoPPResponse.hora_registro, fuenteFecha)
            {
                Alignment = Element.ALIGN_RIGHT
            });
            //fin fecha.............................


            //DATOS DE FICHA
            doc.Add(new Paragraph(" Ficha Nº: " + ingresoPPResponse.numero_ficha, fuenteNumeroFicha)
            {
                Alignment = Element.ALIGN_CENTER
            });

            // Crear código de barras
            Barcode128 barcode = new Barcode128();

            barcode.Code = ingresoPPResponse.numero_ficha;
            barcode.CodeType = Barcode.CODE128;
            barcode.StartStopText = true;

            // Tamaño del código de barras
            barcode.BarHeight = 30f;
            barcode.X = 1.2f;

            // Generar la imagen del código de barras
            iTextSharp.text.Image imagenBarcode = barcode.CreateImageWithBarcode(writer.DirectContent,BaseColor.BLACK,BaseColor.BLACK);

            // Centrar código de barras
            imagenBarcode.Alignment = Element.ALIGN_CENTER;

            // Agregar al documento
            doc.Add(imagenBarcode);
            

            doc.Add(new Paragraph(" Visita: " + ingresoPPResponse.ciudadano, fuenteVisita));
            doc.Add(new Paragraph(" Interno: " + ingresoPPResponse.interno, fuenteNormal));
            doc.Add(new Paragraph(" Parentesco: " + ingresoPPResponse.parentesco, fuenteNormal));
            doc.Add(new Paragraph(" Menores: " + ingresoPPResponse.menores + " " + ingresoPPResponse.menores, fuenteNormal));
            doc.Add(new Paragraph(" Casillero: " + ingresoPPResponse.casillero, fuenteNormal));
            //fin datos ficha


            doc.Close(); // Cierra el documento pero NO el MemoryStream
            ms.Position = 0;

            return ms;
        }

    }
}
