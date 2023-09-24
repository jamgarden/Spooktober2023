using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;


namespace Yarn.Unity
{

    public class UltraProvider : LineProviderBehaviour
    {

        [Language]
        public string textLanguageCode = System.Globalization.CultureInfo.CurrentCulture.Name;
        public override LocalizedLine GetLocalizedLine(Line line)
        {
            var text = YarnProject.GetLocalization(textLanguageCode).GetLocalizedString(line.ID);

            return new LocalizedLine()
            {
                TextID = line.ID,
                RawText = text,
                Substitutions = line.Substitutions,
                Metadata = YarnProject.lineMetadata.GetMetadata(line.ID),
            };
        }

        public override string LocaleCode => textLanguageCode;
    }

}