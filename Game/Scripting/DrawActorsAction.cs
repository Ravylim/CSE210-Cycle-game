using System.Collections.Generic;
using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An output action that draws all the actors.</para>
    /// <para>The responsibility of DrawActorsAction is to draw each of the actors.</para>
    /// </summary>
    public class DrawActorsAction : Action
    {
        private VideoService videoService;

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public DrawActorsAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            Snake snake = (Snake)cast.GetFirstActor("snake");
            Snake tron = (Snake)cast.GetFirstActor("tron");
            List<Actor> segments = snake.GetSegments();
            List<Actor> segment = tron.GetSegments();
            Actor score = cast.GetFirstActor("score");
            Actor score2 = cast.GetFirstActor("score2");
            Actor food = cast.GetFirstActor("food");
            List<Actor> messages = cast.GetActors("messages");
            
            videoService.ClearBuffer();
            videoService.DrawActors(segments);
            videoService.DrawActors(segment);
            videoService.DrawActor(score);
            videoService.DrawActor(score2);
            // videoService.DrawActor(food);
            videoService.DrawActors(messages);
            videoService.FlushBuffer();
        }
    }
}