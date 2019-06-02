using System;

namespace NHeroes2.ResourceNs
{
    internal class Artifact
    {
        private int id;
        private int ext;
        public Artifact(int artifactKind)
        {
            id = artifactKind;
        }

        public static Artifact FromMP2IndexSprite(uint addonIndex)
        {
            throw new System.NotImplementedException();
        }

        public static int Rand(ArtifactLevel artUltimate)
        {
            throw new System.NotImplementedException();
        }
        public string GetName()
        {
            throw new NotImplementedException();
        }
    }
}