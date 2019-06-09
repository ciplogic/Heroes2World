using NHeroes2.Engine;

namespace NHeroes2.ResourceNs
{
    internal class UltimateArtifact : Artifact
    {
        private int index;
        private bool isfound;
        private Surface puzzlemap = new Surface();

        public UltimateArtifact(int artifactKind) : base(artifactKind)
        {
        }

        public void Set(int pos, Artifact a)
        {
            Artifact art = this;
            art = a.IsValid() ? a : new Artifact(Rand(ArtifactLevel.ART_ULTIMATE));
            index = pos;
            isfound = false;

            MakeSurface();
        }

        private void MakeSurface()
        {
            //TODO: make puzzle 
        }
    }
}