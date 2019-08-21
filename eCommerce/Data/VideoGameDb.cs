﻿using eCommerce.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Data
{
    /// <summary>
    /// DB Helper class for VideoGames
    /// </summary>
    public static class VideoGameDb
    {
        /// <summary>
        /// Adds a VideoGame to the data store and sets the ID value
        /// </summary>
        /// <param name="g">The game to add</param>
        /// <param name="context">The DB context to use</param>
        public static async Task<VideoGame> Add(VideoGame g, GameContext context)
        {
            await context.AddAsync(g);
            await context.SaveChangesAsync();
            return g;
        }

        /// <summary>
        /// Retrieves all games sorted in alphabetical order by title.
        /// </summary>
        /// <param name="context"></param>
        /// <returns>A list of all games retrieved</returns>
        public static async Task<List<VideoGame>> GetAllGames(GameContext context)
        {
            //LINQ Query Syntax
            //List<VideoGame> games = await (from vidGame in context.VideoGames
            //                         orderby vidGame.Title ascending
            //                         select vidGame).ToListAsync();


            //LINQ Method Syntax
            List<VideoGame> games = await context.VideoGames
                                    .OrderBy(g => g.Title)
                                    .ToListAsync();
            return games;
        }
    }
}
