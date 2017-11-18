﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.IO;
using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties;
using Com.OfficerFlake.Libraries.YSFlight.Types;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT
{
    public partial class File : CommandFile, ILoadable, ISaveable
    {
        private bool DebugMode = false;
        public List<PropertyTypes.Property> Properties { get; }

        public File(string filename) : base(filename)
        {
            Properties = new List<PropertyTypes.Property>();
        }

        public new bool Load()
        {
            const bool ShowLines = false;
            const string nullExceptionString = "<ERROR-DAT.File.Load()>";

            Properties.Clear();
            var errorsEncountered = false;
            var numberErrorsEncounted = 0;
            base.Load();
            foreach (var thisLine in Lines)
            {
                if (thisLine.Command == "") continue;
                if (Comments.StartOfLineMarkers.Contains(thisLine.Command)) continue;
                if (DebugMode && ShowLines) Debug.WriteLine(thisLine);
                #region switch (thisLine.Command) ...
                switch (thisLine.Command)
                {
                    case "AAMSLOT_":
                        {
                            Length x;
                            Length y;
                            Length z;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out x)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(1) ?? nullExceptionString).ToString(), out y)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(2) ?? nullExceptionString).ToString(), out z)) goto Error;
                            Properties.Add(new AAMSLOT_(x, y, z));
                            continue;
                        }
                    case "AAMVISIB":
                        {
                            bool value;
                            if (!bool.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new AAMVISIB(value));
                            continue;
                        }
                    case "AFTBURNR":
                        {
                            bool value;
                            if (!bool.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new AFTBURNR(value));
                            continue;
                        }
                    case "AGMSLOT_":
                        {
                            Length x;
                            Length y;
                            Length z;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out x)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(1) ?? nullExceptionString).ToString(), out y)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(2) ?? nullExceptionString).ToString(), out z)) goto Error;
                            Properties.Add(new AGMSLOT_(x, y, z));
                            continue;
                        }
                    case "AGMVISIB":
                        {
                            bool value;
                            if (!bool.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new AGMVISIB(value));
                            continue;
                        }
                    case "AIRCLASS":
                        {
                            string value = (thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString();
                            Properties.Add(new AIRCLASS(value));
                            continue;
                        }
                    case "ARRESTER":
                        {
                            Length x;
                            Length y;
                            Length z;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out x)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(1) ?? nullExceptionString).ToString(), out y)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(2) ?? nullExceptionString).ToString(), out z)) goto Error;
                            Properties.Add(new ARRESTER(x, y, z));
                            continue;
                        }
                    case "ATTITUDE":
                        {
                            Angle h;
                            Angle p;
                            Angle b;
                            if (!Angle.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out h)) goto Error;
                            if (!Angle.TryParse((thisLine.GetParameterOrNull(1) ?? nullExceptionString).ToString(), out p)) goto Error;
                            if (!Angle.TryParse((thisLine.GetParameterOrNull(2) ?? nullExceptionString).ToString(), out b)) goto Error;
                            Properties.Add(new ATTITUDE(h, p, b));
                            continue;
                        }
                    case "AUTOCALC":
                        {
                            Properties.Add(new AUTOCALC());
                            continue;
                        }

                    case "BMBAYRCS":
                        {
                            float value;
                            if (!float.TryParse(((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString()).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
                            Properties.Add(new BMBAYRCS(value));
                            continue;
                        }
                    case "BOMBSLOT":
                        {
                            Length x;
                            Length y;
                            Length z;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out x)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(1) ?? nullExceptionString).ToString(), out y)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(2) ?? nullExceptionString).ToString(), out z)) goto Error;
                            Properties.Add(new BOMBSLOT(x, y, z));
                            continue;
                        }
                    case "BOMINBAY":
                        {
                            bool value;
                            if (!bool.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new BOMINBAY(value));
                            continue;
                        }

                    case "BOMVISIB":
                        {
                            bool value;
                            if (!bool.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new BOMVISIB(value));
                            continue;
                        }
                    case "CATEGORY":
                        {
                            var Value = (thisLine.GetParameterOrNull(0) ?? "ERR").ToString();
                            var SubValue = (thisLine.GetParameterOrNull(1) ?? "ERR").ToString();
                            AircraftCategory value = AircraftCategory.GetCategoryFromStringOrBlank(Value, SubValue);
                            if (value == null) goto Error;
                            Properties.Add(new CATEGORY(value));
                            continue;
                        }
                    case "CDBYFLAP":
                        {
                            float value;
                            if (!float.TryParse(((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString()).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
                            Properties.Add(new CDBYFLAP(value));
                            continue;
                        }
                    case "CDBYGEAR":
                        {
                            float value;
                            if (!float.TryParse(((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString()).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
                            Properties.Add(new CDBYGEAR(value));
                            continue;
                        }
                    case "CDSPOILR":
                        {
                            float value;
                            if (!float.TryParse(((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString()).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
                            Properties.Add(new CDSPOILR(value));
                            continue;
                        }
                    case "CDVARGEO":
                        {
                            float value;
                            if (!float.TryParse(((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString()).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
                            Properties.Add(new CDVARGEO(value));
                            continue;
                        }
                    case "CKPITHUD":
                        {
                            bool value;
                            if (!bool.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new CKPITHUD(value));
                            continue;
                        }
                    case "CKPITIST":
                        {
                            bool value;
                            if (!bool.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new CKPITIST(value));
                            continue;
                        }
                    case "CLBYFLAP":
                        {
                            float value;
                            if (!float.TryParse(((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString()).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
                            Properties.Add(new CLBYFLAP(value));
                            continue;
                        }
                    case "CLDECAY1":
                        {
                            Angle value;
                            if (!Angle.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new CLDECAY1(value));
                            continue;
                        }
                    case "CLDECAY2":
                        {
                            Angle value;
                            if (!Angle.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new CLDECAY2(value));
                            continue;
                        }
                    case "CLVARGEO":
                        {
                            float value;
                            if (!float.TryParse(((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString()).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
                            Properties.Add(new CLVARGEO(value));
                            continue;
                        }
                    case "COCKPITA":
                        {
                            Angle h;
                            Angle p;
                            Angle b;
                            if (!Angle.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out h)) goto Error;
                            if (!Angle.TryParse((thisLine.GetParameterOrNull(1) ?? nullExceptionString).ToString(), out p)) goto Error;
                            if (!Angle.TryParse((thisLine.GetParameterOrNull(2) ?? nullExceptionString).ToString(), out b)) goto Error;
                            Properties.Add(new COCKPITA(h, p, b));
                            continue;
                        }
                    case "COCKPITP":
                        {
                            Length x;
                            Length y;
                            Length z;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out x)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(1) ?? nullExceptionString).ToString(), out y)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(2) ?? nullExceptionString).ToString(), out z)) goto Error;
                            Properties.Add(new COCKPITP(x, y, z));
                            continue;
                        }
                    case "CPITMANE":
                        {
                            float value;
                            if (!float.TryParse(((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString()).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
                            Properties.Add(new CPITMANE(value));
                            continue;
                        }
                    case "CPITSTAB":
                        {
                            float value;
                            if (!float.TryParse(((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString()).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
                            Properties.Add(new CPITSTAB(value));
                            continue;
                        }

                    case "CRITAOAM":
                        {
                            Angle value;
                            if (!Angle.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new CRITAOAM(value));
                            continue;
                        }
                    case "CRITAOAP":
                        {
                            Angle value;
                            if (!Angle.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new CRITAOAP(value));
                            continue;
                        }
                    case "CRITSPED":
                        {
                            Speed value;
                            if (!Speed.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new CRITSPED(value));
                            continue;
                        }
                    case "CROLLMAN":
                        {
                            float value;
                            if (!float.TryParse(((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString()).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
                            Properties.Add(new CROLLMAN(value));
                            continue;
                        }

                    case "CTLABRNR":
                        {
                            bool value;
                            if (!bool.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new CTLABRNR(value));
                            continue;
                        }
                    case "CTLATVGW":
                        {
                            bool value;
                            if (!bool.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new CTLATVGW(value));
                            continue;
                        }
                    case "CTLBRAKE":
                        {
                            bool value;
                            if (!bool.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new CTLBRAKE(value));
                            continue;
                        }
                    case "CTLIFLAP":
                        {
                            float value;
                            if (!float.TryParse(((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString()).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
                            Properties.Add(new CTLIFLAP(value));
                            continue;
                        }
                    case "CTLINVGW":
                        {
                            float value;
                            if (!float.TryParse(((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString()).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
                            Properties.Add(new CTLINVGW(value));
                            continue;
                        }
                    case "CTLLDGEA":
                        {
                            bool value;
                            if (!bool.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new CTLLDGEA(value));
                            continue;
                        }
                    case "CTLSPOIL":
                        {
                            float value;
                            if (!float.TryParse(((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString()).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
                            Properties.Add(new CTLSPOIL(value));
                            continue;
                        }
                    case "CTLTHROT":
                        {
                            float value;
                            if (!float.TryParse(((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString()).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
                            Properties.Add(new CTLTHROT(value));
                            continue;
                        }
                    case "CYAWMANE":
                        {
                            float value;
                            if (!float.TryParse(((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString()).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
                            Properties.Add(new CYAWMANE(value));
                            continue;
                        }
                    case "CYAWSTAB":
                        {
                            float value;
                            if (!float.TryParse(((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString()).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
                            Properties.Add(new CYAWSTAB(value));
                            continue;
                        }
                    case "EXCAMERA":
                        {
                            Length x;
                            Length y;
                            Length z;
                            Angle h;
                            Angle p;
                            Angle b;
                            var name = (thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString();
                            if (!Length.TryParse((thisLine.GetParameterOrNull(1) ?? nullExceptionString).ToString(), out x)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(2) ?? nullExceptionString).ToString(), out y)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(3) ?? nullExceptionString).ToString(), out z)) goto Error;
                            if (!Angle.TryParse((thisLine.GetParameterOrNull(4) ?? nullExceptionString).ToString(), out h)) goto Error;
                            if (!Angle.TryParse((thisLine.GetParameterOrNull(5) ?? nullExceptionString).ToString(), out p)) goto Error;
                            if (!Angle.TryParse((thisLine.GetParameterOrNull(6) ?? nullExceptionString).ToString(), out b)) goto Error;
                            Properties.Add(new EXCAMERA(name, x, y, z, h, p, b));
                            continue;
                        }
                    case "FLAPPOSI":
                        {
                            float value;
                            if (!float.TryParse(((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString()).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
                            Properties.Add(new FLAPPOSI(value));
                            continue;
                        }
                    case "FLAREPOS":
                        {
                            Length x1;
                            Length y1;
                            Length z1;
                            Length x2; //SECOND PARAMETER IS OPTIONAL.
                            Length y2;
                            Length z2;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out x1)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(1) ?? nullExceptionString).ToString(), out y1)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(2) ?? nullExceptionString).ToString(), out z1)) goto Error;
                            if (!Length.TryParse(thisLine.GetParameterOrNull(3).ToString() ?? "0M", out x2)) goto Error;
                            if (!Length.TryParse(thisLine.GetParameterOrNull(4).ToString() ?? "0M", out y2)) goto Error;
                            if (!Length.TryParse(thisLine.GetParameterOrNull(5).ToString() ?? "0M", out z2)) goto Error;
                            Properties.Add(new FLAREPOS(x1, y1, z1, x2, y2, z2));
                            continue;
                        }
                    case "FLATCLR1":
                        {
                            Angle value;
                            if (!Angle.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new FLATCLR1(value));
                            continue;
                        }
                    case "FLATCLR2":
                        {
                            Angle value;
                            if (!Angle.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new FLATCLR2(value));
                            continue;
                        }
                    case "FUELMILI":
                        {
                            Mass value;
                            if (!Mass.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new FUELMILI(value));
                            continue;
                        }
                    case "FUELABRN":
                        {
                            Mass value;
                            if (!Mass.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new FUELABRN(value));
                            continue;
                        }
                    case "GEARHORN":
                        {
                            bool value;
                            if (!bool.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new GEARHORN(value));
                            continue;
                        }
                    case "GUNDIREC":
                        {
                            Length x;
                            Length y;
                            Length z;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out x)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(1) ?? nullExceptionString).ToString(), out y)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(2) ?? nullExceptionString).ToString(), out z)) goto Error;
                            Properties.Add(new GUNDIREC(x, y, z));
                            continue;
                        }
                    case "GUNINTVL":
                        {
                            float value;
                            if (!float.TryParse(((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString()).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
                            Properties.Add(new GUNINTVL(value));
                            continue;
                        }
                    case "GUNPOWER":
                        {
                            float value;
                            if (!float.TryParse(((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString()).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
                            Properties.Add(new GUNPOWER(value));
                            continue;
                        }
                    case "GUNSIGHT":
                        {
                            bool value;
                            if (!bool.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new GUNSIGHT(value));
                            continue;
                        }
                    case "HASSPOIL":
                        {
                            bool value;
                            if (!bool.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new HASSPOIL(value));
                            continue;
                        }
                    case "HRDPOINT":
                        {
                            Length x;
                            Length y;
                            Length z;
                            var descriptors = new List<WeaponDescription>();
                            if (!Length.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out x)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(1) ?? nullExceptionString).ToString(), out y)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(2) ?? nullExceptionString).ToString(), out z)) goto Error;
                            for (var i = 3; i < thisLine.NumberOfParameters; i++)
                            {
                                try
                                {
                                    if ((string)(thisLine.GetParameterOrNull(i) ?? nullExceptionString) == "") continue;
                                    var thisDescriptor = new WeaponDescription((thisLine.GetParameterOrNull(i) ?? nullExceptionString).ToString());
                                    descriptors.Add(thisDescriptor);
                                }
                                catch
                                {
                                    goto Error;
                                }
                            }
                            Properties.Add(new HRDPOINT(x, y, z, descriptors.ToArray()));
                            continue;
                        }
                    case "HTRADIUS":
                        {
                            Length value;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new HTRADIUS(value));
                            continue;
                        }
                    case "IDENTIFY":
                        {
                            string value = (thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString();
                            Properties.Add(new IDENTIFY(value));
                            continue;
                        }
                    case "INITAAMM":
                        {
                            int value;
                            if (!int.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new INITAAMM(value));
                            continue;
                        }
                    case "INITBOMB":
                        {
                            int value;
                            if (!int.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new INITBOMB(value));
                            continue;
                        }
                    case "INITFUEL":
                        {
                            float value;
                            if (!Percentages.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new INITFUEL(value));
                            continue;
                        }
                    case "INITIAAM":
                        {
                            int value;
                            if (!int.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new INITIAAM(value));
                            continue;
                        }
                    case "INITIAGM":
                        {
                            int value;
                            if (!int.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new INITIAGM(value));
                            continue;
                        }
                    case "INITIGUN":
                        {
                            int value;
                            if (!int.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new INITIGUN(value));
                            continue;
                        }
                    case "INITLOAD":
                        {
                            Mass value;
                            if (!Mass.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new INITLOAD(value));
                            continue;
                        }
                    case "INITRCKT":
                        {
                            int value;
                            if (!int.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new INITRCKT(value));
                            continue;
                        }
                    case "INITSPED":
                        {
                            Speed value;
                            if (!Speed.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new INITSPED(value));
                            continue;
                        }
                    case "INSTPANL":
                        {
                            string value = (thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString();
                            Properties.Add(new INSTPANL(value));
                            continue;
                        }
                    case "ISPNLATT":
                        {
                            Angle h;
                            Angle p;
                            Angle b;
                            if (!Angle.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out h)) goto Error;
                            if (!Angle.TryParse((thisLine.GetParameterOrNull(1) ?? nullExceptionString).ToString(), out p)) goto Error;
                            if (!Angle.TryParse((thisLine.GetParameterOrNull(2) ?? nullExceptionString).ToString(), out b)) goto Error;
                            Properties.Add(new ISPNLATT(h, p, b));
                            continue;
                        }
                    case "ISPNLHUD":
                        {
                            bool value;
                            if (!bool.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new ISPNLHUD(value));
                            continue;
                        }
                    case "ISPNLPOS":
                        {
                            Length x;
                            Length y;
                            Length z;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out x)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(1) ?? nullExceptionString).ToString(), out y)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(2) ?? nullExceptionString).ToString(), out z)) goto Error;
                            Properties.Add(new ISPNLPOS(x, y, z));
                            continue;
                        }
                    case "ISPNLSCL":
                        {
                            float value;
                            if (!float.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new ISPNLSCL(value));
                            continue;
                        }
                    case "LEFTGEAR":
                        {
                            Length x;
                            Length y;
                            Length z;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out x)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(1) ?? nullExceptionString).ToString(), out y)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(2) ?? nullExceptionString).ToString(), out z)) goto Error;
                            Properties.Add(new LEFTGEAR(x, y, z));
                            continue;
                        }
                    case "LMTBYHDP":
                        {
                            bool value;
                            if (!bool.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new LMTBYHDP(value));
                            continue;
                        }
                    case "LOADWEPN":
                        {
                            var Value = (thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString() ?? "";
                            WeaponType value =
                                WeaponType.CATEGORIES.FirstOrDefault(
                                    x => (x.Value == Value));
                            if (value == null) goto Error;
                            int quantity;
                            if (!int.TryParse((thisLine.GetParameterOrNull(1) ?? nullExceptionString).ToString(), out quantity)) goto Error;
                            Properties.Add(new LOADWEPN(value, quantity));
                            continue;
                        }
                    case "MACHNGN2":
                        {
                            Length x;
                            Length y;
                            Length z;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out x)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(1) ?? nullExceptionString).ToString(), out y)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(2) ?? nullExceptionString).ToString(), out z)) goto Error;
                            Properties.Add(new MACHNGN2(x, y, z));
                            continue;
                        }
                    case "MACHNGN3":
                        {
                            Length x;
                            Length y;
                            Length z;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out x)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(1) ?? nullExceptionString).ToString(), out y)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(2) ?? nullExceptionString).ToString(), out z)) goto Error;
                            Properties.Add(new MACHNGN3(x, y, z));
                            continue;
                        }

                    case "MACHNGN4":
                        {
                            Length x;
                            Length y;
                            Length z;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out x)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(1) ?? nullExceptionString).ToString(), out y)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(2) ?? nullExceptionString).ToString(), out z)) goto Error;
                            Properties.Add(new MACHNGN4(x, y, z));
                            continue;
                        }

                    case "MACHNGN5":
                        {
                            Length x;
                            Length y;
                            Length z;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out x)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(1) ?? nullExceptionString).ToString(), out y)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(2) ?? nullExceptionString).ToString(), out z)) goto Error;
                            Properties.Add(new MACHNGN5(x, y, z));
                            continue;
                        }

                    case "MACHNGN6":
                        {
                            Length x;
                            Length y;
                            Length z;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out x)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(1) ?? nullExceptionString).ToString(), out y)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(2) ?? nullExceptionString).ToString(), out z)) goto Error;
                            Properties.Add(new MACHNGN6(x, y, z));
                            continue;
                        }

                    case "MACHNGN7":
                        {
                            Length x;
                            Length y;
                            Length z;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out x)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(1) ?? nullExceptionString).ToString(), out y)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(2) ?? nullExceptionString).ToString(), out z)) goto Error;
                            Properties.Add(new MACHNGN7(x, y, z));
                            continue;
                        }

                    case "MACHNGN8":
                        {
                            Length x;
                            Length y;
                            Length z;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out x)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(1) ?? nullExceptionString).ToString(), out y)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(2) ?? nullExceptionString).ToString(), out z)) goto Error;
                            Properties.Add(new MACHNGN8(x, y, z));
                            continue;
                        }
                    case "MACHNGUN":
                        {
                            Length x;
                            Length y;
                            Length z;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out x)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(1) ?? nullExceptionString).ToString(), out y)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(2) ?? nullExceptionString).ToString(), out z)) goto Error;
                            Properties.Add(new MACHNGUN(x, y, z));
                            continue;
                        }
                    case "MANESPD1":
                        {
                            Speed speed;
                            if (!Speed.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out speed)) goto Error;
                            Properties.Add(new MANESPD1(speed));
                            continue;
                        }
                    case "MANESPD2":
                        {
                            Speed speed;
                            if (!Speed.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out speed)) goto Error;
                            Properties.Add(new MANESPD2(speed));
                            continue;
                        }
                    case "MAXCDAOA":
                        {
                            Angle value;
                            if (!Angle.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new MAXCDAOA(value));
                            continue;
                        }
                    case "MAXNAAMM":
                        {
                            int value;
                            if (!int.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new MAXNAAMM(value));
                            continue;
                        }
                    case "MAXNBOMB":
                        {
                            int value;
                            if (!int.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new MAXNBOMB(value));
                            continue;
                        }
                    case "MAXNMAAM":
                        {
                            int value;
                            if (!int.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new MAXNMAAM(value));
                            continue;
                        }
                    case "MAXNMAGM":
                        {
                            int value;
                            if (!int.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new MAXNMAGM(value));
                            continue;
                        }
                    case "MAXNMFLR":
                        {
                            int value;
                            if (!int.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new MAXNMFLR(value));
                            continue;
                        }
                    case "MAXNMRKT":
                        {
                            int value;
                            if (!int.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new MAXNMRKT(value));
                            continue;
                        }
                    case "MAXSPEED":
                        {
                            Speed speed;
                            if (!Speed.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out speed)) goto Error;
                            Properties.Add(new MAXSPEED(speed));
                            continue;
                        }
                    case "MXIPTAOA":
                        {
                            Angle angle;
                            if (!Angle.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out angle)) goto Error;
                            Properties.Add(new MXIPTAOA(angle));
                            continue;
                        }
                    case "MXIPTROL":
                        {
                            Angle angle;
                            if (!Angle.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out angle)) goto Error;
                            Properties.Add(new MXIPTROL(angle));
                            continue;
                        }
                    case "MXIPTSSA":
                        {
                            Angle angle;
                            if (!Angle.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out angle)) goto Error;
                            Properties.Add(new MXIPTSSA(angle));
                            continue;
                        }
                    case "NMTURRET":
                        {
                            int value;
                            if (!int.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new MAXNMFLR(value));
                            continue;
                        }
                    case "POSITION":
                        {
                            Length x;
                            Length y;
                            Length z;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out x)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(1) ?? nullExceptionString).ToString(), out y)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(2) ?? nullExceptionString).ToString(), out z)) goto Error;
                            Properties.Add(new POSITION(x, y, z));
                            continue;
                        }
                    case "PROPEFCY":
                        {
                            float value;
                            if (!float.TryParse(((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString()).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
                            Properties.Add(new PROPEFCY(value));
                            continue;
                        }
                    case "PROPELLR":
                        {
                            Power value;
                            if (!Power.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new PROPELLR(value));
                            continue;
                        }
                    case "PROPVMIN":
                        {
                            Speed value;
                            if (!Speed.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new PROPVMIN(value));
                            continue;
                        }
                    case "PSTMPTCH":
                        {
                            Angle angle;
                            if (!Angle.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out angle)) goto Error;
                            Properties.Add(new PSTMPTCH(angle));
                            continue;
                        }
                    case "PSTMPWR1":
                        {
                            float value;
                            if (!float.TryParse(((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString()).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
                            Properties.Add(new PSTMPWR1(value));
                            continue;
                        }
                    case "PSTMPWR2":
                        {
                            float value;
                            if (!float.TryParse(((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString()).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
                            Properties.Add(new PSTMPWR2(value));
                            continue;
                        }
                    case "PSTMROLL":
                        {
                            Angle angle;
                            if (!Angle.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out angle)) goto Error;
                            Properties.Add(new PSTMROLL(angle));
                            continue;
                        }
                    case "PSTMSPD1":
                        {
                            Speed value;
                            if (!Speed.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new PSTMSPD1(value));
                            continue;
                        }
                    case "PSTMSPD2":
                        {
                            Speed value;
                            if (!Speed.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new PSTMSPD2(value));
                            continue;
                        }
                    case "PSTMYAW_":
                        {
                            Angle angle;
                            if (!Angle.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out angle)) goto Error;
                            Properties.Add(new PSTMYAW_(angle));
                            continue;
                        }
                    case "RADARCRS":
                        {
                            float value;
                            if (!float.TryParse(((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString()).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
                            Properties.Add(new RADARCRS(value));
                            continue;
                        }
                    case "REFACRUS":
                        {
                            Length value;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new REFACRUS(value));
                            continue;
                        }
                    case "REFAOALD":
                        {
                            Angle angle;
                            if (!Angle.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out angle)) goto Error;
                            Properties.Add(new REFAOALD(angle));
                            continue;
                        }
                    case "REFLNRWY":
                        {
                            Length value;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new REFLNRWY(value));
                            continue;
                        }
                    case "REFTCRUS":
                        {
                            float value;
                            if (!float.TryParse(((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString()).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
                            Properties.Add(new REFTCRUS(value));
                            continue;
                        }
                    case "REFTHRLD":
                        {
                            float value;
                            if (!float.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new REFTHRLD(value));
                            continue;
                        }
                    case "REFVCRUS":
                        {
                            Speed speed;
                            if (!Speed.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out speed)) goto Error;
                            Properties.Add(new REFVCRUS(speed));
                            continue;
                        }
                    case "REFVLAND":
                        {
                            Speed speed;
                            if (!Speed.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out speed)) goto Error;
                            Properties.Add(new REFVLAND(speed));
                            continue;
                        }
                    case "RETRGEAR":
                        {
                            bool value;
                            if (!bool.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new RETRGEAR(value));
                            continue;
                        }
                    case "RIGHGEAR":
                        {
                            Length x;
                            Length y;
                            Length z;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out x)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(1) ?? nullExceptionString).ToString(), out y)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(2) ?? nullExceptionString).ToString(), out z)) goto Error;
                            Properties.Add(new RIGHGEAR(x, y, z));
                            continue;
                        }
                    case "RKTSLOT_":
                        {
                            Length x;
                            Length y;
                            Length z;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out x)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(1) ?? nullExceptionString).ToString(), out y)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(2) ?? nullExceptionString).ToString(), out z)) goto Error;
                            Properties.Add(new RKTSLOT_(x, y, z));
                            continue;
                        }
                    case "RKTVISIB":
                        {
                            bool value;
                            if (!bool.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new RKTVISIB(value));
                            continue;
                        }
                    case "SCRNCNTR":
                        {
                            float x;
                            float y;
                            if (!float.TryParse(((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString()).ExtractNumberComponentFromMeasurementString(), out x)) goto Error;
                            if (!float.TryParse(((thisLine.GetParameterOrNull(1) ?? nullExceptionString).ToString()).ExtractNumberComponentFromMeasurementString(), out y)) goto Error;
                            Properties.Add(new SCRNCNTR(x, y));
                            continue;
                        }
                    case "SMOKECOL":
                        {
                            byte n;
                            byte r;
                            byte g;
                            byte b;
                            if (!byte.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out n)) goto Error;
                            if (!byte.TryParse((thisLine.GetParameterOrNull(1) ?? nullExceptionString).ToString(), out r)) goto Error;
                            if (!byte.TryParse((thisLine.GetParameterOrNull(2) ?? nullExceptionString).ToString(), out g)) goto Error;
                            if (!byte.TryParse((thisLine.GetParameterOrNull(3) ?? nullExceptionString).ToString(), out b)) goto Error;
                            Properties.Add(new SMOKECOL(n,r,g,b));
                            continue;
                        }
                    case "SMOKEGEN":
                        {
                            Length x;
                            Length y;
                            Length z;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out x)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(1) ?? nullExceptionString).ToString(), out y)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(2) ?? nullExceptionString).ToString(), out z)) goto Error;
                            Properties.Add(new SMOKEGEN(x, y, z));
                            continue;
                        }
                    case "SMOKEOIL":
                        {
                            Mass value;
                            if (!Mass.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new SMOKEOIL(value));
                            continue;
                        }
                    case "STALHORN":
                        {
                            bool value;
                            if (!bool.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new STALHORN(value));
                            continue;
                        }
                    case "STRENGTH":
                        {
                            int value;
                            if (!int.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new STRENGTH(value));
                            continue;
                        }
                    case "SUBSTNAM":
                        {
                            string value = (thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString();
                            Properties.Add(new SUBSTNAM(value));
                            continue;
                        }
                    case "THRAFTBN":
                        {
                            Mass value;
                            if (!Mass.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new THRAFTBN(value));
                            continue;
                        }
                    case "THRMILIT":
                        {
                            Mass value;
                            if (!Mass.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new THRMILIT(value));
                            continue;
                        }
                    case "THRSTREV":
                        {
                            float value;
                            if (!float.TryParse(((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString()).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
                            Properties.Add(new THRSTREV(value));
                            continue;
                        }
                    case "TRIGGER1":
                        {
                            var Value = (thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString() ?? "";
                            WeaponCategory value = WeaponCategory.GetCategoryFromStringOrBlank(Value);
                            if (value == null) goto Error;
                            Properties.Add(new TRIGGER1(value));
                            continue;
                        }
                    case "TRIGGER2":
                        {
                            var Value = (thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString() ?? "";
                            WeaponCategory value = WeaponCategory.GetCategoryFromStringOrBlank(Value);
                            if (value == null) goto Error;
                            Properties.Add(new TRIGGER2(value));
                            continue;
                        }
                    case "TRIGGER3":
                        {
                            var Value = (thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString() ?? "";
                            WeaponCategory value = WeaponCategory.GetCategoryFromStringOrBlank(Value);
                            if (value == null) goto Error;
                            Properties.Add(new TRIGGER3(value));
                            continue;
                        }
                    case "TRIGGER4":
                        {
                            var Value = (thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString() ?? "";
                            WeaponCategory value = WeaponCategory.GetCategoryFromStringOrBlank(Value);
                            if (value == null) goto Error;
                            Properties.Add(new TRIGGER4(value));
                            continue;
                        }
                    case "TRSTDIR0":
                        {
                            Length x;
                            Length y;
                            Length z;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out x)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(1) ?? nullExceptionString).ToString(), out y)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(2) ?? nullExceptionString).ToString(), out z)) goto Error;
                            Properties.Add(new TRSTDIR0(x, y, z));
                            continue;
                        }
                    case "TRSTDIR1":
                        {
                            Length x;
                            Length y;
                            Length z;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out x)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(1) ?? nullExceptionString).ToString(), out y)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(2) ?? nullExceptionString).ToString(), out z)) goto Error;
                            Properties.Add(new TRSTDIR1(x, y, z));
                            continue;
                        }
                    case "TRSTVCTR":
                        {
                            bool value;
                            if (!bool.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new TRSTVCTR(value));
                            continue;
                        }
                    case "TURRETAM":
                        {
                            int quantifier;
                            int value;
                            if (!int.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out quantifier)) goto Error;
                            if (!int.TryParse((thisLine.GetParameterOrNull(1) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new TURRETAM(quantifier, value));
                            continue;
                        }
                    case "TURRETAR":
                        {
                            int value;
                            if (!int.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new TURRETAR(value));
                            continue;
                        }
                    case "TURRETCT":
                        {
                            int quantifier;
                            if (!int.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out quantifier)) goto Error;
                            string value = (thisLine.GetParameterOrNull(1) ?? nullExceptionString).ToString();
                            Properties.Add(new TURRETCT(quantifier, value));
                            continue;
                        }
                    case "TURRETGD":
                        {
                            int value;
                            if (!int.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new TURRETGD(value));
                            continue;
                        }
                    case "TURRETHD":
                        {
                            int quantifier;
                            Angle h;
                            Angle p;
                            Angle b;
                            if (!int.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out quantifier)) goto Error;
                            if (!Angle.TryParse((thisLine.GetParameterOrNull(1) ?? nullExceptionString).ToString(), out h)) goto Error;
                            if (!Angle.TryParse((thisLine.GetParameterOrNull(2) ?? nullExceptionString).ToString(), out p)) goto Error;
                            if (!Angle.TryParse((thisLine.GetParameterOrNull(3) ?? nullExceptionString).ToString(), out b)) goto Error;
                            Properties.Add(new TURRETHD(quantifier,h,p,b));
                            continue;
                        }
                    case "TURRETIV":
                        {
                            int quantifier;
                            TimeSpan interval;
                            if (!int.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out quantifier)) goto Error;
                            if (!UnitsOfMeasurement.Time.TryParse((thisLine.GetParameterOrNull(1) ?? nullExceptionString).ToString(), out interval)) goto Error;
                            Properties.Add(new TURRETIV(quantifier, interval));
                            continue;
                        }
                    case "TURRETNM":
                        {
                            int quantifier;
                            if (!int.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out quantifier)) goto Error;
                            var name = (thisLine.GetParameterOrNull(1) ?? nullExceptionString).ToString();
                            Properties.Add(new TURRETNM(quantifier, name));
                            continue;
                        }
                    case "TURRETPO":
                        {
                            int quantifier;
                            Length x;
                            Length y;
                            Length z;
                            Angle h;
                            Angle p;
                            Angle b;
                            if (!int.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out quantifier)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(1) ?? nullExceptionString).ToString(), out x)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(2) ?? nullExceptionString).ToString(), out y)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(3) ?? nullExceptionString).ToString(), out z)) goto Error;
                            if (!Angle.TryParse((thisLine.GetParameterOrNull(4) ?? nullExceptionString).ToString(), out h)) goto Error;
                            if (!Angle.TryParse((thisLine.GetParameterOrNull(5) ?? nullExceptionString).ToString(), out p)) goto Error;
                            if (!Angle.TryParse((thisLine.GetParameterOrNull(6) ?? nullExceptionString).ToString(), out b)) goto Error;
                            Properties.Add(new TURRETPO(quantifier,x,y,z,h, p, b));
                            continue;
                        }
                    case "TURRETPT":
                        {
                            int quantifier;
                            Angle h;
                            Angle p;
                            Angle b;
                            if (!int.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out quantifier)) goto Error;
                            if (!Angle.TryParse((thisLine.GetParameterOrNull(1) ?? nullExceptionString).ToString(), out h)) goto Error;
                            if (!Angle.TryParse((thisLine.GetParameterOrNull(2) ?? nullExceptionString).ToString(), out p)) goto Error;
                            if (!Angle.TryParse((thisLine.GetParameterOrNull(3) ?? nullExceptionString).ToString(), out b)) goto Error;
                            Properties.Add(new TURRETPT(quantifier, h, p, b));
                            continue;
                        }
                    case "TURRETRG":
                        {
                            int quantifier;
                            Length value;
                            if (!int.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out quantifier)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(1) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new TURRETRG(quantifier, value));
                            continue;
                        }
                    case "VAPORPO0":
                        {
                            Length x;
                            Length y;
                            Length z;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out x)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(1) ?? nullExceptionString).ToString(), out y)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(2) ?? nullExceptionString).ToString(), out z)) goto Error;
                            Properties.Add(new VAPORPO0(x, y, z));
                            continue;
                        }
                    case "VAPORPO1":
                        {
                            Length x;
                            Length y;
                            Length z;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out x)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(1) ?? nullExceptionString).ToString(), out y)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(2) ?? nullExceptionString).ToString(), out z)) goto Error;
                            Properties.Add(new VAPORPO1(x, y, z));
                            continue;
                        }
                    case "VARGEOMW":
                        {
                            bool value;
                            if (!bool.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new VARGEOMW(value));
                            continue;
                        }
                    case "VGWSPED1":
                        {
                            Speed value;
                            if (!Speed.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new VGWSPED1(value));
                            continue;
                        }
                    case "VGWSPED2":
                        {
                            Speed value;
                            if (!Speed.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new VGWSPED2(value));
                            continue;
                        }
                    case "VRGMNOSE":
                        {
                            bool value;
                            if (!bool.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new VRGMNOSE(value));
                            continue;
                        }
                    case "WEAPONCH":
                        {
                            var Value = (thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString() ?? "";
                            WeaponCategory value = WeaponCategory.GetCategoryFromStringOrBlank(Value);
                            if (value == null) goto Error;
                            Properties.Add(new WEAPONCH(value));
                            continue;
                        }
                    case "WEIGFUEL":
                        {
                            Mass value;
                            if (!Mass.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new WEIGFUEL(value));
                            continue;
                        }
                    case "WEIGHCLN":
                        {
                            Mass value;
                            if (!Mass.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new WEIGHCLN(value));
                            continue;
                        }
                    case "WEIGLOAD":
                        {
                            Mass value;
                            if (!Mass.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new WEIGLOAD(value));
                            continue;
                        }
                    case "WHELGEAR":
                        {
                            Length x;
                            Length y;
                            Length z;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out x)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(1) ?? nullExceptionString).ToString(), out y)) goto Error;
                            if (!Length.TryParse((thisLine.GetParameterOrNull(2) ?? nullExceptionString).ToString(), out z)) goto Error;
                            Properties.Add(new WHELGEAR(x, y, z));
                            continue;
                        }
                    case "WINGAREA":
                        {
                            Area value;
                            if (!Area.TryParse((thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString(), out value)) goto Error;
                            Properties.Add(new WINGAREA(value));
                            continue;
                        }

                    case "WPNSHAPE":
                        {
                            var Value = (thisLine.GetParameterOrNull(0) ?? nullExceptionString).ToString() ?? "";
                            var value =
                                WeaponType.CATEGORIES.FirstOrDefault(
                                    x => (x.Value == Value));
                            if (value == null) goto Error;
                            var isStatic = (((thisLine.GetParameterOrNull(1) ?? nullExceptionString).ToString()) == "STATIC");
                            var shape = (thisLine.GetParameterOrNull(2) ?? nullExceptionString).ToString();
                            Properties.Add(new WPNSHAPE(value, isStatic, shape));
                            continue;
                        }


                    default:
                        if (DebugMode) Debug.WriteLine("DAT COMMAND NOT IMPLEMENTED : " + thisLine);
                        continue;

                    Error:
                        if (DebugMode) Debug.WriteLine("BAD DAT COMMAND? : " + thisLine);
                        errorsEncountered = true;
                        numberErrorsEncounted++;
                        continue;
                }
                #endregion
            }
            return !errorsEncountered;
        }
        public new bool Save()
        {
            throw new NotImplementedException();
        }
    }
}
