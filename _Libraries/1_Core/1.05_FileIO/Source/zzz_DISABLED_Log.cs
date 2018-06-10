//namespace Com.OfficerFlake.Libraries.IO.Log
//{
//    public class LogFile : HtmlFile
//    {
//        public LogFile(string filename) : base(filename)
//        {
//            Dom.Head.Css newCSS = new Dom.Head.Css();

//            #region body
//            Dom.Head.Css.Object CssBody = new Dom.Head.Css.Object("body",
//                new Dom.Head.Css.Object.Property("margin-top", "0px"),
//                new Dom.Head.Css.Object.Property("margin-left", "0px"),
//                new Dom.Head.Css.Object.Property("margin-bottom", "0px"), 
//                new Dom.Head.Css.Object.Property("margin-right", "0px"),
//                new Dom.Head.Css.Object.Property("background-color", SimpleColors.Black.ToString()),
//                new Dom.Head.Css.Object.Property("background", "-webkit-linear-gradient(top, rgba(0,32,32,0.8), rgba(0,32,64,0.8))"),
//                new Dom.Head.Css.Object.Property("font-family", "Lucida Console"),
//                new Dom.Head.Css.Object.Property("text-shadow", "1px 1px rgba(0,0,0,0.67)"),
//                new Dom.Head.Css.Object.Property("white-space", "nowrap"));
//            newCSS.Objects.Add(CssBody);
//            #endregion
//            #region p
//            Dom.Head.Css.Object CssP = new Dom.Head.Css.Object("p",
//                new Dom.Head.Css.Object.Property("padding-top", "0px"),
//                new Dom.Head.Css.Object.Property("padding-left", "10px"),
//                new Dom.Head.Css.Object.Property("padding-bottom", "0px"),
//                new Dom.Head.Css.Object.Property("padding-right", "10px"),
//                new Dom.Head.Css.Object.Property("margin", "0px"));
//            newCSS.Objects.Add(CssP);
//			#endregion

//			#region color0
//			Dom.Head.Css.Object cssColor0 = new Dom.Head.Css.Object(".color0",
//				new Dom.Head.Css.Object.Property("color", SimpleColors.Color0.Color.ToString()));
//			#endregion
//			#region color1
//			Dom.Head.Css.Object cssColor1 = new Dom.Head.Css.Object(".color1",
//				new Dom.Head.Css.Object.Property("color", SimpleColors.Color1.Color.ToString()));
//			newCSS.Objects.Add(cssColor1);
//			#endregion
//			#region color2
//			Dom.Head.Css.Object cssColor2 = new Dom.Head.Css.Object(".color2",
//				new Dom.Head.Css.Object.Property("color", SimpleColors.Color2.Color.ToString()));
//			newCSS.Objects.Add(cssColor2);
//			#endregion
//			#region color3
//			Dom.Head.Css.Object cssColor3 = new Dom.Head.Css.Object(".color3",
//				new Dom.Head.Css.Object.Property("color", SimpleColors.Color3.Color.ToString()));
//			newCSS.Objects.Add(cssColor3);
//			#endregion
//			#region color4
//			Dom.Head.Css.Object cssColor4 = new Dom.Head.Css.Object(".color4",
//				new Dom.Head.Css.Object.Property("color", SimpleColors.Color4.Color.ToString()));
//			newCSS.Objects.Add(cssColor4);
//			#endregion
//			#region color5
//			Dom.Head.Css.Object cssColor5 = new Dom.Head.Css.Object(".color5",
//				new Dom.Head.Css.Object.Property("color", SimpleColors.Color5.Color.ToString()));
//			newCSS.Objects.Add(cssColor5);
//			#endregion
//			#region color6
//			Dom.Head.Css.Object cssColor6 = new Dom.Head.Css.Object(".color6",
//				new Dom.Head.Css.Object.Property("color", SimpleColors.Color6.Color.ToString()));
//			newCSS.Objects.Add(cssColor6);
//			#endregion
//			#region color7
//			Dom.Head.Css.Object cssColor7 = new Dom.Head.Css.Object(".color7",
//				new Dom.Head.Css.Object.Property("color", SimpleColors.Color7.Color.ToString()));
//			newCSS.Objects.Add(cssColor7);
//			#endregion
//			#region color8
//			Dom.Head.Css.Object cssColor8 = new Dom.Head.Css.Object(".color8",
//				new Dom.Head.Css.Object.Property("color", SimpleColors.Color8.Color.ToString()));
//			newCSS.Objects.Add(cssColor8);
//			#endregion
//			#region color9
//			Dom.Head.Css.Object cssColor9 = new Dom.Head.Css.Object(".color9",
//				new Dom.Head.Css.Object.Property("color", SimpleColors.Color9.Color.ToString()));
//			newCSS.Objects.Add(cssColor9);
//			#endregion
//			#region colorA
//			Dom.Head.Css.Object cssColorA = new Dom.Head.Css.Object(".colorA",
//				new Dom.Head.Css.Object.Property("color", SimpleColors.ColorA.Color.ToString()));
//			newCSS.Objects.Add(cssColorA);
//			#endregion
//			#region colorB
//			Dom.Head.Css.Object cssColorB = new Dom.Head.Css.Object(".colorB",
//		        new Dom.Head.Css.Object.Property("color", SimpleColors.ColorB.Color.ToString()));
//			newCSS.Objects.Add(cssColorB);
//			#endregion
//			#region colorC
//			Dom.Head.Css.Object cssColorC = new Dom.Head.Css.Object(".colorC",
//				new Dom.Head.Css.Object.Property("color", SimpleColors.ColorC.Color.ToString()));
//			newCSS.Objects.Add(cssColorC);
//			#endregion
//			#region colorD
//			Dom.Head.Css.Object cssColorD = new Dom.Head.Css.Object(".colorD",
//				new Dom.Head.Css.Object.Property("color", SimpleColors.ColorD.Color.ToString()));
//			newCSS.Objects.Add(cssColorD);
//			#endregion
//			#region colorE
//			Dom.Head.Css.Object cssColorE = new Dom.Head.Css.Object(".colorE",
//				new Dom.Head.Css.Object.Property("color", SimpleColors.ColorE.Color.ToString()));
//			newCSS.Objects.Add(cssColorE);
//            #endregion
//            #region colorF
//	        Dom.Head.Css.Object cssColorF = new Dom.Head.Css.Object(".colorF",
//		        new Dom.Head.Css.Object.Property("color", SimpleColors.ColorF.Color.ToString()));
//            newCSS.Objects.Add(cssColorF);
//            #endregion

//            #region bold
//            Dom.Head.Css.Object cssBold = new Dom.Head.Css.Object(".bold",
//                new Dom.Head.Css.Object.Property("font-weight", "bold"));
//            newCSS.Objects.Add(cssBold);
//            #endregion
//            #region italic
//            Dom.Head.Css.Object cssItalic = new Dom.Head.Css.Object(".italic",
//                new Dom.Head.Css.Object.Property("font-style", "italic"));
//            newCSS.Objects.Add(cssItalic);
//            #endregion
//            #region strikethrough
//            Dom.Head.Css.Object cssStrikethrough = new Dom.Head.Css.Object(".strikethrough",
//                new Dom.Head.Css.Object.Property("text-decoration", "line-through"));
//            newCSS.Objects.Add(cssStrikethrough);
//            #endregion
//            #region underline
//            Dom.Head.Css.Object cssUnderline = new Dom.Head.Css.Object(".underline",
//                new Dom.Head.Css.Object.Property("text-decoration", "underline"));
//            newCSS.Objects.Add(cssUnderline);
//            #endregion

//            #region p.unknown
//            Dom.Head.Css.Object cssPUnknown = new Dom.Head.Css.Object("p.unknown",
//                new Dom.Head.Css.Object.Property("padding-top", "0px"),
//                new Dom.Head.Css.Object.Property("padding-bottom", "0px"),
//                new Dom.Head.Css.Object.Property("background-color", "rgba(170,170,170,0.1)"));
//                //new Head.Css.Object.Property("font-size", "100%"),
//                //new Head.Css.Object.Property("text-transform", "uppercase"));
//            newCSS.Objects.Add(cssPUnknown);
//            #endregion
//            #region p.crash
//            Dom.Head.Css.Object cssPCrash = new Dom.Head.Css.Object("p.crash",
//                new Dom.Head.Css.Object.Property("padding-top", "20px"),
//                new Dom.Head.Css.Object.Property("padding-bottom", "20px"),
//                new Dom.Head.Css.Object.Property("background-color", "rgba(240,0,0,0.8)"),
//                new Dom.Head.Css.Object.Property("font-size", "150%"),
//                new Dom.Head.Css.Object.Property("text-transform", "uppercase"));
//            newCSS.Objects.Add(cssPCrash);
//            #endregion
//            #region p.error
//            Dom.Head.Css.Object cssPError = new Dom.Head.Css.Object("p.error",
//                new Dom.Head.Css.Object.Property("padding-top", "15px"),
//                new Dom.Head.Css.Object.Property("padding-bottom", "15px"),
//                new Dom.Head.Css.Object.Property("background-color", "rgba(250,50,0,0.6)"),
//                new Dom.Head.Css.Object.Property("font-size", "125%"),
//                new Dom.Head.Css.Object.Property("text-transform", "uppercase"));
//            newCSS.Objects.Add(cssPError);
//            #endregion
//            #region p.debug
//            Dom.Head.Css.Object cssPDebug = new Dom.Head.Css.Object("p.debug",
//                new Dom.Head.Css.Object.Property("padding-top", "0px"),
//                new Dom.Head.Css.Object.Property("padding-bottom", "0px"),
//                new Dom.Head.Css.Object.Property("background-color", "rgba(0,100,200,0.5)"));
//            //new Head.Css.Object.Property("font-size", "100%"),
//            //new Head.Css.Object.Property("text-transform", "uppercase"));
//            newCSS.Objects.Add(cssPDebug);
//            #endregion
//            #region p.warning
//            Dom.Head.Css.Object cssPWarning = new Dom.Head.Css.Object("p.warning",
//                new Dom.Head.Css.Object.Property("padding-top", "10px"),
//                new Dom.Head.Css.Object.Property("padding-bottom", "10px"),
//                new Dom.Head.Css.Object.Property("background-color", "rgba(250,200,0,0.5)"));
//            //new Head.Css.Object.Property("font-size", "100%"),
//            //new Head.Css.Object.Property("text-transform", "uppercase"));
//            newCSS.Objects.Add(cssPWarning);
//            #endregion
//            #region p.information
//            Dom.Head.Css.Object cssPInformation = new Dom.Head.Css.Object("p.information",
//                new Dom.Head.Css.Object.Property("padding-top", "0px"),
//                new Dom.Head.Css.Object.Property("padding-bottom", "0px"),
//                new Dom.Head.Css.Object.Property("background-color", "rgba(250,0,200,0.2)"));
//            //new Head.Css.Object.Property("font-size", "100%"),
//            //new Head.Css.Object.Property("text-transform", "uppercase"));
//            newCSS.Objects.Add(cssPInformation);
//            #endregion

//            Head.Stylesheets.Add(newCSS);
//        }
//    }
//}
