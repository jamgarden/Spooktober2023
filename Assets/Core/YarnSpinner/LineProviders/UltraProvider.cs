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
        [SerializeField] private PARAMETER_ID yarnLines;
        [SerializeField] private StudioEventEmitter stopVO;
        private FMOD.Studio.EventInstance otherInstance;

        

        private string currentID;
        [Language]
        public string textLanguageCode = System.Globalization.CultureInfo.CurrentCulture.Name;
        public override LocalizedLine GetLocalizedLine(Line line)
        {
            
            // throwAway is there to hold the original instance
            FMOD.Studio.EventInstance throwAway = otherInstance;
            throwAway.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            otherInstance = RuntimeManager.CreateInstance(eventReference);
            var text = YarnProject.GetLocalization(textLanguageCode).GetLocalizedString(line.ID);
            currentID = line.ID;
            
            string clean = line.ID.Remove(4, 1);
            currentID = clean;
            UnityEngine.Debug.Log(clean);

            FMOD.Studio.EventDescription eventDescription;
            FMODUnity.RuntimeManager.StudioSystem.getEvent("event:/VoiceLines/YarnVoiceLinePlayer", out eventDescription);
            

            otherInstance.setParameterByNameWithLabel("YarnLines", clean, false);
            otherInstance.start();

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