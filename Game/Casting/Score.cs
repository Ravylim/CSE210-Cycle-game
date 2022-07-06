using System;


namespace Unit05.Game.Casting
{
    /// <summary>
    /// <para>A tasty item that snakes like to eat.</para>
    /// <para>
    /// The responsibility of Food is to select a random position and points that it's worth.
    /// </para>
    /// </summary>
    public class Score : Actor
    {
        private int points = 0;
        private int player = 0;

        /// <summary>
        /// Constructs a new instance of an Food.
        /// </summary>
        public Score(int x, int y, int player)
        {
            Point point = new Point(x, y);
            AddPoints(0);
            SetPosition(point);
            this.player = player;
            SetText($"Player{this.player}: {this.points}");
        }

        /// <summary>
        /// Adds the given points to the score.
        /// </summary>
        /// <param name="points">The points to add.</param>
        public void AddPoints(int points)
        {
            this.points += points;
            SetText($"Player{this.player}: {this.points}");
        }
    }
}