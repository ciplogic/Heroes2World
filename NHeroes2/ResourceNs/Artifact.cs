using System;

namespace NHeroes2.ResourceNs
{
    internal class Artifact
    {
        private int ext;
        private int id;

        public Artifact(int artifactKind)
        {
            id = artifactKind;
        }

        public static Artifact FromMP2IndexSprite(uint addonIndex)
        {
            throw new NotImplementedException();
        }

        public static int Rand(ArtifactLevel artUltimate)
        {
            throw new NotImplementedException();
        }

        public string GetName()
        {
            throw new NotImplementedException();
        }
    }
}