using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace painting.models
{
    public class PaintingData
    {
        public class Painting
        {
            public int elapsedMilliseconds { get; set; }
            public Artobject artObject { get; set; }
            public Artobjectpage artObjectPage { get; set; }
        }

        public class Artobject
        {
            public Links links { get; set; }
            public string id { get; set; }
            public string priref { get; set; }
            public string objectNumber { get; set; }
            public string language { get; set; }
            public string title { get; set; }
            public object copyrightHolder { get; set; }
            public Webimage webImage { get; set; }
            public string[] colors { get; set; }
            public Colorswithnormalization[] colorsWithNormalization { get; set; }
            public string[] normalizedColors { get; set; }
            public string[] normalized32Colors { get; set; }
            public string[] titles { get; set; }
            public string description { get; set; }
            public object labelText { get; set; }
            public string[] objectTypes { get; set; }
            public string[] objectCollection { get; set; }
            public object[] makers { get; set; }
            public Principalmaker[] principalMakers { get; set; }
            public string plaqueDescriptionDutch { get; set; }
            public object plaqueDescriptionEnglish { get; set; }
            public string principalMaker { get; set; }
            public object artistRole { get; set; }
            public object[] associations { get; set; }
            public Acquisition acquisition { get; set; }
            public object[] exhibitions { get; set; }
            public string[] materials { get; set; }
            public object[] techniques { get; set; }
            public string[] productionPlaces { get; set; }
            public Dating dating { get; set; }
            public Classification classification { get; set; }
            public bool hasImage { get; set; }
            public string[] historicalPersons { get; set; }
            public object[] inscriptions { get; set; }
            public string[] documentation { get; set; }
            public object[] catRefRPK { get; set; }
            public string principalOrFirstMaker { get; set; }
            public Dimension[] dimensions { get; set; }
            public object[] physicalProperties { get; set; }
            public string physicalMedium { get; set; }
            public string longTitle { get; set; }
            public string subTitle { get; set; }
            public string scLabelLine { get; set; }
            public Label label { get; set; }
            public bool showImage { get; set; }
            public string location { get; set; }
        }

        public class Links
        {
            public string search { get; set; }
        }

        public class Webimage
        {
            public string guid { get; set; }
            public int offsetPercentageX { get; set; }
            public int offsetPercentageY { get; set; }
            public int width { get; set; }
            public int height { get; set; }
            public string url { get; set; }
        }

        public class Acquisition
        {
            public object method { get; set; }
            public DateTime date { get; set; }
            public string creditLine { get; set; }
        }

        public class Dating
        {
            public DateTime early { get; set; }
            public object earlyPrecision { get; set; }
            public DateTime late { get; set; }
            public object latePrecision { get; set; }
            public int year { get; set; }
            public int yearEarly { get; set; }
            public int yearLate { get; set; }
            public int period { get; set; }
        }

        public class Classification
        {
            public string[] iconClassIdentifier { get; set; }
            public string[] iconClassDescription { get; set; }
            public object[] motifs { get; set; }
            public object[] events { get; set; }
            public object[] periods { get; set; }
            public string[] places { get; set; }
            public string[] people { get; set; }
            public string[] objectNumbers { get; set; }
        }

        public class Label
        {
            public string title { get; set; }
            public string makerLine { get; set; }
            public object description { get; set; }
            public object notes { get; set; }
            public string date { get; set; }
        }

        public class Colorswithnormalization
        {
            public string originalHex { get; set; }
            public string normalizedHex { get; set; }
        }

        public class Principalmaker
        {
            public string name { get; set; }
            public string unFixedName { get; set; }
            public string placeOfBirth { get; set; }
            public string dateOfBirth { get; set; }
            public object dateOfBirthPrecision { get; set; }
            public string dateOfDeath { get; set; }
            public object dateOfDeathPrecision { get; set; }
            public string placeOfDeath { get; set; }
            public string[] occupation { get; set; }
            public string[] roles { get; set; }
            public string nationality { get; set; }
            public object biography { get; set; }
            public string[] productionPlaces { get; set; }
            public object qualification { get; set; }
        }

        public class Dimension
        {
            public string unit { get; set; }
            public string type { get; set; }
            public object part { get; set; }
            public string value { get; set; }
        }

        public class Artobjectpage
        {
            public string id { get; set; }
            public object[] similarPages { get; set; }
            public string lang { get; set; }
            public string objectNumber { get; set; }
            public object[] tags { get; set; }
            public object plaqueDescription { get; set; }
            public object audioFile1 { get; set; }
            public object audioFileLabel1 { get; set; }
            public object audioFileLabel2 { get; set; }
            public DateTime createdOn { get; set; }
            public DateTime updatedOn { get; set; }
            public Adliboverrides adlibOverrides { get; set; }
        }

        public class Adliboverrides
        {
            public object titel { get; set; }
            public object maker { get; set; }
            public object etiketText { get; set; }
        }

    }
}
