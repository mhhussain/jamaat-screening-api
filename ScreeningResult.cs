using System;

namespace jamaat_screening_api
{
    public class ScreeningResult
    {
        public string Name { get; set; }

        public Boolean Fever { get; set; }

        public Boolean Cough { get; set; }

        public Boolean SoreThroat { get; set; }

        public Boolean ShortnessOfBreath { get; set; }

        public Boolean LossOfTasteOrSmell { get; set; }

        public Boolean NoSymptoms { get; set; }

        public Boolean ContactWithCovid { get; set; }

        public Boolean Travel14Days { get; set; }
    }
}