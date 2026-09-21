using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.IO;
using CapaDatos;
using System.Windows.Forms;
using CommonCache;
using System.Globalization;

namespace CapaPresentacion.Reportes.AdministrarVisita
{
    public class ReportesAdminVisitaPDF
    {
                
        //VINCULOS DE LA VISITA         
        public static MemoryStream RepPdfInternosVinculados(DCiudadano ciudadanox,List<DVisitaInterno>listaVinculos)
        {
            MemoryStream ms = new MemoryStream();

            Document doc = new Document(PageSize.A4.Rotate(), 20, 20, 20, 20);

            PdfWriter writer = PdfWriter.GetInstance(doc, ms);
            writer.CloseStream = false; // evita cerrar el MemoryStream al cerrar el documento

            doc.Open();

            var fuenteLogo = FontFactory.GetFont(FontFactory.TIMES, 8, BaseColor.BLACK);
            var fuenteOrganismo = FontFactory.GetFont(FontFactory.TIMES, 8, BaseColor.BLACK);
            var fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.BLACK);
            var fuenteNormal = FontFactory.GetFont(FontFactory.HELVETICA, 9, BaseColor.BLACK);

            //logo encabezado
            //string rutaImagen = Path.Combine(Application.StartupPath, "Resources/Img-reportes/", "logo_spps2.png");
            //iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(rutaImagen);

            // Cargar directamente desde Resources
            System.Drawing.Image logoImg = Properties.Resources.logo_spps2;
            // Convertir a iTextSharp Image
            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(logoImg, System.Drawing.Imaging.ImageFormat.Png);
            string organismo = CurrentUser.Instance.organismo.ToUpper();
            logo.ScaleAbsolute(40, 40);
            logo.SetAbsolutePosition(150, 770);
            doc.Add(logo);
            //doc.Add(new Paragraph(" "));

            // Crear tabla con 2 columnas
            PdfPTable tablaEncabezado = new PdfPTable(1);
            tablaEncabezado.WidthPercentage = 16; // ocupa la mitad de la página
            tablaEncabezado.HorizontalAlignment = Element.ALIGN_LEFT; // tabla a la izquierda

            // Centrar contenido de todas las celdas
            tablaEncabezado.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tablaEncabezado.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            tablaEncabezado.DefaultCell.Border = Rectangle.NO_BORDER;

            // Agregar celdas
            tablaEncabezado.AddCell(new Paragraph("SERVICIO PENITENCIARIO \n DE LA PROVINCIA DE SALTA", fuenteLogo)
            {
                Alignment = Element.ALIGN_LEFT
            });

            tablaEncabezado.AddCell(new Paragraph(organismo, fuenteOrganismo));

            // Agregar tabla al documento
            doc.Add(tablaEncabezado);
            //fin logo encabezado.....................................

            //fecha
            DateTime fechaHoy = DateTime.Now;
            CultureInfo cultura = new CultureInfo("es-ES");

            // "d 'de' MMMM 'de' yyyy" → ejemplo: "9 de septiembre de 2025"
            string fechaCompleta = "Salta, " + fechaHoy.ToString("d 'de' MMMM 'de' yyyy", cultura);

            doc.Add(new Paragraph(fechaCompleta, fuenteNormal)
            {
                Alignment = Element.ALIGN_RIGHT
            });
            //fin fecha.............................


            //datos ciudadano
            doc.Add(new Paragraph(" Apellido y nombre: " + ciudadanox.apellido + " " + ciudadanox.nombre , fuenteNormal));
            doc.Add(new Paragraph(" DNI: " + ciudadanox.dni, fuenteNormal));
            doc.Add(new Paragraph(" Sexo: " + ciudadanox.sexo.sexo + "      Edad: " + ciudadanox.edad, fuenteNormal));
            
            //fin datos ciudadano

            Paragraph titulo = new Paragraph("Vinculos de la visita", fuenteTitulo);
            titulo.Alignment = Element.ALIGN_CENTER;
            doc.Add(titulo);
            doc.Add(new Paragraph (" "));

            PdfPTable tablaVinculos = new PdfPTable(8);
            tablaVinculos.WidthPercentage = 100;
            tablaVinculos.SetWidths(new float[] { 2.7f, 0.9f, 1.4f, 0.7f, 0.7f, 0.8f, 0.8f, 2.5f });
            tablaVinculos.AddCell(new Paragraph("Interno", fuenteTitulo));
            tablaVinculos.AddCell(new Paragraph("Parentesco", fuenteTitulo));
            tablaVinculos.AddCell(new Paragraph("Unidad", fuenteTitulo));
            tablaVinculos.AddCell(new Paragraph("Vigente", fuenteTitulo));
            tablaVinculos.AddCell(new Paragraph("Prohibido", fuenteTitulo));
            tablaVinculos.AddCell(new Paragraph("Inicio", fuenteTitulo));
            tablaVinculos.AddCell(new Paragraph("Fin", fuenteTitulo));
            tablaVinculos.AddCell(new Paragraph("Detalle", fuenteTitulo));

            // Filas dinámicas
            foreach (var vinculo in listaVinculos)
            {
                tablaVinculos.AddCell(new Paragraph(vinculo.interno.apellido.ToString() + " " + vinculo.interno.nombre.ToString(), fuenteNormal));
                tablaVinculos.AddCell(new Paragraph(vinculo.parentesco.parentesco,fuenteNormal));
                tablaVinculos.AddCell(new Paragraph(vinculo.interno.organismo.organismo.ToString(), fuenteNormal));
                tablaVinculos.AddCell(new Paragraph(vinculo.vigente ? "SI" : "NO", fuenteNormal));
                tablaVinculos.AddCell(new Paragraph(vinculo.prohibido ? "SI" : "NO", fuenteNormal));
                tablaVinculos.AddCell(new Paragraph(vinculo.fecha_inicio?.ToString("dd/MM/yyyy") ?? "", fuenteNormal));
                tablaVinculos.AddCell(new Paragraph(vinculo.fecha_fin?.ToString("dd/MM/yyyy") ?? "", fuenteNormal));
                tablaVinculos.AddCell(new Paragraph(vinculo.detalles_prohibicion, fuenteNormal));

            }

            doc.Add(tablaVinculos);

            doc.Close(); // Cierra el documento pero NO el MemoryStream
            ms.Position = 0;

            return ms;
        }
    
    } 
    
}
