using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DevAnalytics.AnalyticsShared
{

    class AnalyticsException : Exception
    {
        public AnalyticsException(string? message) : base(message)
        {
        }
    }
    
    /// <summary>
    /// Represents developer entity (can also be QA). This allows us
    /// to link work to him, and also resolve ambiguities using metadata
    /// (like ambiguities, link from certain different sources with different IDs).
    /// </summary>
    public sealed class Developer
    {
        public string Id { get; }
        public string? Name { get; set; }
        public string? Email { get; set; }

        public Developer(string id)
        {
            Id = id;
        }
    }

    public interface IDeveloperResolver
    {
        // Resolves developer from id; id can be any string, like email (git), or
        // short name. This interface allows linking of different IDs system to the
        // same developer instance, usually by providing metadata.
        Developer GetOrCreateDeveloperFromId(string id);
    }

    public class DeveloperResolver : IDeveloperResolver
    {
        private readonly List<Developer> developers = new();
        private readonly List<(string, Developer)> idsToDeveloper = new();


        public void AddDeveloperId(Developer who, string additionalId)
        {
            Debug.Assert(developers.Contains(who), "Must contain the developer to add id to it");
            idsToDeveloper.Add((additionalId, who));
        }
        
        public Developer GetOrCreateDeveloperFromId(string id)
        {
            // First try to find it in developer by id, name or email
            Developer? developer = developers.Find(x => x.Name == id || x.Email == id || x.Id == id);
            if (developer != null)
            {
                return developer;
            }
            
            // Try to find by extended id (including match)
            var results = idsToDeveloper.FindAll(x => x.Item1.Contains(id));
            switch (results.Count)
            {
             case 0:
                 developer = new Developer(id);
                developers.Add(developer);
                return developer;
             case 1:
                 return results[0].Item2;
             default:
                 throw new AnalyticsException("Could not resolve developer id, it is ambitious between " +
                                              string.Join(",", results.Select(x => x.Item1)));
            }
            

        }
    }
}