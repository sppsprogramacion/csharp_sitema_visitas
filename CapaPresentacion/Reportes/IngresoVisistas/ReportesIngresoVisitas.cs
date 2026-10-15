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
        //GENERAR FICHA INGRESO
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
        //FIN GENERAR FICHA INGRESO
        //------------------------------------------------------------------------------------

        //REIMPRIMIR FICHA INGRESO
        public static MemoryStream RepPdfFichaIngresoReimpresion(DEntradaSalidaControl ingresoPPResponse)
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
            doc.Add(new Paragraph("REIMPRESION - Ficha Nº: " + ingresoPPResponse.numero_ficha, fuenteNumeroFicha)
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
            iTextSharp.text.Image imagenBarcode = barcode.CreateImageWithBarcode(writer.DirectContent, BaseColor.BLACK, BaseColor.BLACK);

            // Centrar código de barras
            imagenBarcode.Alignment = Element.ALIGN_CENTER;

            // Agregar al documento
            doc.Add(imagenBarcode);


            doc.Add(new Paragraph(" Visita: " + ingresoPPResponse.nombre_visita, fuenteVisita));
            doc.Add(new Paragraph(" Interno: " + ingresoPPResponse.nombre_interno, fuenteNormal));
            doc.Add(new Paragraph(" Parentesco: " + ingresoPPResponse.parentesco, fuenteNormal));
            doc.Add(new Paragraph(" Menores: " + ingresoPPResponse.menores + " " + ingresoPPResponse.menores, fuenteNormal));
            doc.Add(new Paragraph(" Casillero: " + ingresoPPResponse.casillero, fuenteNormal));
            //fin datos ficha


            doc.Close(); // Cierra el documento pero NO el MemoryStream
            ms.Position = 0;

            return ms;
        }
        //FIN REIMPRIMIR FICHA INGRESO
        //------------------------------------------------------------------------------------

        //COMPUTO DE VISITAS
        public static MemoryStream RepPdfComputoVisitas(DComputoVisitas datos)
        {
            MemoryStream ms = new MemoryStream();
         

            float mmToPoints = 2.8346457f;

            // Papel térmico de 80 mm, sin rotación
            float anchoPagina = 75f * mmToPoints;
            float altoPagina = 75f * mmToPoints;

            Document doc = new Document(new Rectangle(anchoPagina, altoPagina),
                5f,  // izquierda: aproximadamente 4,2 mm
                15f,  // derecha: aproximadamente 4,2 mm
                5f,   // arriba
                5f    // abajo
            );

            PdfWriter writer = PdfWriter.GetInstance(doc, ms);
            writer.CloseStream = false;

            doc.Open();

            //PdfContentByte cb = writer.DirectContent;

            //cb.SetLineWidth(1f);

            //cb.MoveTo(5f, altoPagina - 2f);
            //cb.LineTo(anchoPagina - 15f, altoPagina - 2f);

            //cb.Stroke();

            // FUENTES
            var fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11, BaseColor.BLACK);

            var fuenteEncabezado = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8, BaseColor.BLACK);

            var fuenteNormal = FontFactory.GetFont(FontFactory.HELVETICA, 9, BaseColor.BLACK);

            var fuenteNumeros = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.BLACK);

            // ENCABEZADO
            
            string organismo = CurrentUser.Instance.organismo.ToUpper();

            doc.Add(new Paragraph("S.P.P.S. - " + organismo, fuenteNormal)
            {
                Alignment = Element.ALIGN_LEFT,
                SpacingAfter = 3f
            });
                        

            doc.Add(new Paragraph( "COMPUTO DE VISITAS: " + DateTime.Now.ToString("dd/MM/yyyy"), fuenteTitulo)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 3f
            });

            

            // CALCULAR TOTALES
            int totalAdultos = datos.AdultosMasculinos + datos.AdultosFemeninos + datos.AdultosNoBinarios;

            int totalMenores = datos.MenoresMasculinos + datos.MenoresFemeninos + datos.MenoresNoBinarios;

            int totalMasculinos = datos.AdultosMasculinos + datos.MenoresMasculinos;

            int totalFemeninos = datos.AdultosFemeninos + datos.MenoresFemeninos;

            int totalNoBinarios = datos.AdultosNoBinarios + datos.MenoresNoBinarios;

            int totalGeneral = totalAdultos + totalMenores;

            // TABLA PRINCIPAL
            PdfPTable tabla = new PdfPTable(5);

            tabla.WidthPercentage = 100;

            tabla.SetWidths(new float[]
{
                20f,  // Categoría
                15f,  // Masculino
                15f,  // Femenino
                15f,  // No binario
                15f   // Totales
            });

            tabla.SpacingBefore = 3f;

            // Función para agregar celdas
            void AgregarCelda(string texto, Font fuente,
                int alineacion = Element.ALIGN_CENTER)
            {
                PdfPCell celda = new PdfPCell(new Phrase(texto, fuente));

                celda.HorizontalAlignment = alineacion;
                celda.VerticalAlignment = Element.ALIGN_MIDDLE;

                celda.PaddingTop = 7f;
                celda.PaddingBottom = 7f;
                celda.PaddingLeft = 1f;
                celda.PaddingRight = 1f;

                celda.BorderWidth = 0.6f;
                celda.NoWrap = false;

                tabla.AddCell(celda);
            }

            // ENCABEZADOS
            AgregarCelda("CATEG.", fuenteEncabezado);
            AgregarCelda("MASC.", fuenteEncabezado);
            AgregarCelda("FEM.", fuenteEncabezado);
            AgregarCelda("NOBIN", fuenteEncabezado);
            AgregarCelda("TOTAL", fuenteEncabezado);

            // ADULTOS
            AgregarCelda("ADULTOS", fuenteEncabezado);
            AgregarCelda(datos.AdultosMasculinos.ToString(), fuenteNumeros);
            AgregarCelda(datos.AdultosFemeninos.ToString(), fuenteNumeros);
            AgregarCelda(datos.AdultosNoBinarios.ToString(), fuenteNumeros);
            AgregarCelda(totalAdultos.ToString(), fuenteNumeros);

            // MENORES
            AgregarCelda("MENORES", fuenteEncabezado);
            AgregarCelda(datos.MenoresMasculinos.ToString(), fuenteNumeros);
            AgregarCelda(datos.MenoresFemeninos.ToString(), fuenteNumeros);
            AgregarCelda(datos.MenoresNoBinarios.ToString(), fuenteNumeros);
            AgregarCelda(totalMenores.ToString(), fuenteNumeros);

            // TOTALES
            AgregarCelda("TOTALES", fuenteEncabezado);
            AgregarCelda(totalMasculinos.ToString(), fuenteNumeros);
            AgregarCelda(totalFemeninos.ToString(), fuenteNumeros);
            AgregarCelda(totalNoBinarios.ToString(), fuenteNumeros);
            AgregarCelda(totalGeneral.ToString(), fuenteNumeros);

            doc.Add(tabla);

            doc.Close();

            ms.Position = 0;

            return ms;
        }
        //FIN COMPUTO VISITAS
        //--------------------------------------------------------------------------------------------



        //ROTAR COMPUTO
        public static MemoryStream RotarPdfParaTermica(MemoryStream pdfOriginal)
        {
            MemoryStream resultado = new MemoryStream();

            pdfOriginal.Position = 0;

            using (PdfReader reader = new PdfReader(pdfOriginal.ToArray()))
            {
                float mm = 2.8346457f;

                float anchoPapel = 80f * mm;
                float largoPapel = 120f * mm;

                Document documento = new Document(
                    new Rectangle(anchoPapel, largoPapel),
                    0, 0, 0, 0
                );

                PdfWriter writer = PdfWriter.GetInstance(documento, resultado);
                writer.CloseStream = false;

                documento.Open();

                PdfContentByte contenido = writer.DirectContent;

                PdfImportedPage pagina = writer.GetImportedPage(reader, 1);

                // Rotación de 90 grados y desplazamiento
                // para centrar los 72 mm sobre el papel de 80 mm.
                float desplazamiento = 4f * mm;

                contenido.AddTemplate(
                    pagina,
                    0, -1,
                    1, 0,
                    desplazamiento, largoPapel
                );

                documento.Close();
            }

            resultado.Position = 0;

            return resultado;
        }

        //FIN ROTAR COMPUTO
        //-------------------------------------------------------------------------
    }
}
