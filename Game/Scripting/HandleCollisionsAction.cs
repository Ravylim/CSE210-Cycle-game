using System;
using System.Collections.Generic;
using System.Data;
using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An update action that handles interactions between the actors.</para>
    /// <para>
    /// The responsibility of HandleCollisionsAction is to handle the situation when the snake 
    /// collides with the food, or the snake collides with its segments, or the game is over.
    /// </para>
    /// </summary>
    public class HandleCollisionsAction : Action
    {
        private bool isGameOver = false;

        /// <summary>
        /// Constructs a new instance of HandleCollisionsAction.
        /// </summary>
        public HandleCollisionsAction()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            if (isGameOver == false)
            {
                HandleFoodCollisions(cast);
                HandleSegmentCollisions(cast);
                HandleEnemyCollisions(cast);
                HandleGameOver(cast);
            }
        }

        /// <summary>
        /// Updates the score nd moves the food if the snake collides with it.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleFoodCollisions(Cast cast)
        {
            Snake snake = (Snake)cast.GetFirstActor("snake");
            Snake tron = (Snake)cast.GetFirstActor("tron");
            Score score = (Score)cast.GetFirstActor("score");
            Food food = (Food)cast.GetFirstActor("food");

            
            if (snake.GetHead().GetPosition().Equals(food.GetPosition()))
            {
                int points = food.GetPoints();
                snake.GrowTail(points);
                score.AddPoints(points);
                food.Reset();
            }
            if (isGameOver == false )
            {
                snake.GrowTail(1);
                tron.GrowTail(1);
                // score.AddPoints(1);
            }
        }

        /// <summary>
        /// Sets the game over flag if the snake collides with one of its segments.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleSegmentCollisions(Cast cast)
        {
            Snake snake = (Snake)cast.GetFirstActor("snake");
            Snake tron = (Snake)cast.GetFirstActor("tron");
            Actor head = snake.GetHead();
            Actor head2 = tron.GetHead();
            List<Actor> body = snake.GetBody();
            List<Actor> body2 = tron.GetBody();
            Score score = (Score)cast.GetFirstActor("score");
            Score score2 = (Score)cast.GetFirstActor("score2");

            foreach (Actor segment in body)
            {
                if (segment.GetPosition().Equals(head.GetPosition()))
                {
                    isGameOver = true;
                    score2.AddPoints(1);
                }
            }
            foreach (Actor segment in body2)
            {
                if (segment.GetPosition().Equals(head2.GetPosition()))
                {
                    isGameOver = true;
                    score.AddPoints(1);
                }
            }
        }
        private void HandleEnemyCollisions(Cast cast)
        {
             Snake snake = (Snake)cast.GetFirstActor("snake");
            Snake tron = (Snake)cast.GetFirstActor("tron");
            Actor head = snake.GetHead();
            Actor head2 = tron.GetHead();
            List<Actor> body = snake.GetBody();
            List<Actor> body2 = tron.GetBody();
            Score score = (Score)cast.GetFirstActor("score");
            Score score2 = (Score)cast.GetFirstActor("score2");

            foreach (Actor segment in body)
            {
                if (segment.GetPosition().Equals(head2.GetPosition()))
                {
                    isGameOver = true;
                    score.AddPoints(1);
                }
            }
            foreach (Actor segment in body2)
            {
                if (segment.GetPosition().Equals(head.GetPosition()))
                {
                    isGameOver = true;
                    score2.AddPoints(1);                   
                }
            }
        }

        private void HandleGameOver(Cast cast)
        {
            if (isGameOver == true)
            {
                Snake snake = (Snake)cast.GetFirstActor("snake");
                Snake tron = (Snake)cast.GetFirstActor("tron");
                List<Actor> segments = snake.GetSegments();
                List<Actor> segments2 = tron.GetSegments();
                Food food = (Food)cast.GetFirstActor("food");              

                // create a "game over" message
                int x = Constants.MAX_X / 2;
                int y = Constants.MAX_Y / 2;
                Point position = new Point(x, y);

                Actor message = new Actor();
                message.SetText("Game Over!");
                message.SetPosition(position);
                cast.AddActor("messages", message);

                // make everything white
                foreach (Actor segment in segments)
                {
                    segment.SetColor(Constants.WHITE);
                }
                food.SetColor(Constants.WHITE);
                foreach (Actor segment in segments2)
                {
                    segment.SetColor(Constants.WHITE);
                }
                food.SetColor(Constants.WHITE);
            }
        }

    }
}