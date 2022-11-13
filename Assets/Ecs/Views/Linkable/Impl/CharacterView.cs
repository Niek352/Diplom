using JCMG.EntitasRedux;

namespace Ecs.Views.Linkable.Impl
{
    public class CharacterView : ObjectView
    {
        public override void Link(IEntity entity, IContext context)
        {
            var e = (GameEntity)entity;
            base.Link(entity, context);
        }
    }
}