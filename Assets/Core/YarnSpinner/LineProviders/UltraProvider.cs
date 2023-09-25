using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using FMODUnity;
using FMOD;
using FMOD.Studio;

namespace Yarn.Unity
{
    
    public class UltraProvider : LineProviderBehaviour
    {
        [SerializeField] private StudioEventEmitter emitter;
        [SerializeField] private EventReference eventReference;

        private string currentID;
        [Language]
        public string textLanguageCode = System.Globalization.CultureInfo.CurrentCulture.Name;
        public override LocalizedLine GetLocalizedLine(Line line)
        {
            var text = YarnProject.GetLocalization(textLanguageCode).GetLocalizedString(line.ID);
            currentID = line.ID;
            emitter.Stop();
            string clean = line.ID.Remove(4, 1);
            currentID = clean;
            UnityEngine.Debug.Log(clean);
            FMODUnity.RuntimeManager.StudioSystem.setParameterByNameWithLabel("YarnLines", clean);
            emitter.Play(); 

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