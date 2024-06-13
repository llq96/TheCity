using System.Linq;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace TheCity.Tests.Utils
{
    public static class ProjectContextAccessor
    {
        public static ProjectContext GetProjectContext()
        {
            var assetGuid = AssetDatabase.FindAssets($"t:prefab ProjectContext", new[] { "Assets/Resources" }).First();
            var assetPath = AssetDatabase.GUIDToAssetPath(assetGuid);
            var projectContext = AssetDatabase.LoadAssetAtPath<ProjectContext>(assetPath);
            return projectContext;
        }

        public static T GetProjectContextComponent<T>() where T : Component
        {
            return GetProjectContext().GetComponent<T>();
        }
    }
}