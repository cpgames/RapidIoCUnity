using System;
using UnityEngine;

namespace cpGames.core.RapidIoC
{
    public static class SceneExtensions
    {
        #region Methods
        public static string GetName(this SceneView scene)
        {
            return CpUnityExtensions.GetSceneName(scene.GetType());
        }

        public static void BindToObjectInScene<T>(
            this SceneView scene,
            string bindingName,
            bool rootContext)
        {
            var contextName = rootContext ? null : scene.ContextName;
            var obj = string.IsNullOrEmpty(bindingName)
                ? scene.transform.FindChildRecursively<T>()
                : scene.transform.FindChildRecursively<T>(bindingName);
            if (obj == null)
            {
                throw new Exception(string.Format(
                    "Failed to bind injection: Could not find <{0}> with name <{1}> in scene <{2}>.",
                    typeof(T).Name, bindingName, scene.GetName()));
            }
            if (string.IsNullOrEmpty(bindingName))
            {
                Rapid.Bind<T>(obj, contextName);
            }
            else
            {
                Rapid.Bind(bindingName, obj, contextName);
            }
        }

        public static void BindToObjectInScene<T>(
            this SceneView scene,
            bool rootContext)
        {
            scene.BindToObjectInScene<T>(null, rootContext);
        }

        public static void BindToObjectInScene<T>(
            this SceneView scene,
            string bindingName)
        {
            scene.BindToObjectInScene<T>(bindingName, false);
        }

        public static void BindToObjectInScene<T>(
            this SceneView scene)
        {
            scene.BindToObjectInScene<T>(null, false);
        }

        public static void BindToAddObjectToScene<TInterface, TImplementation>(
            this SceneView scene,
            string bindingName,
            bool rootContext,
            Transform parent = null)
            where TImplementation : Component, TInterface
        {
            var contextName = rootContext ? null : scene.ContextName;
            if (parent == null) parent = scene.transform;
            var obj = parent.AddChild<TImplementation>();
            if (!string.IsNullOrEmpty(bindingName))
            {
                obj.name = bindingName;
                Rapid.Bind(bindingName, obj, contextName);
            }
            else
            {
                Rapid.Bind<TInterface>(obj, contextName);
            }
        }

        public static void BindToAddObjectToScene<TInterface, TImplementation>(
            this SceneView scene,
            bool rootContext = false,
            Transform parent = null)
            where TImplementation : Component, TInterface
        {
            scene.BindToAddObjectToScene<TInterface, TImplementation>(null, rootContext, parent);
        }

        public static void BindToAddObjectToScene<TImplementation>(
            this SceneView scene,
            string bindingName,
            bool rootContext,
            Transform parent = null)
            where TImplementation : Component
        {
            scene.BindToAddObjectToScene<TImplementation, TImplementation>(bindingName, rootContext, parent);
        }

        public static void BindToAddObjectToScene<TImplementation>(
            this SceneView scene,
            bool rootContext = false,
            Transform parent = null)
            where TImplementation : Component
        {
            scene.BindToAddObjectToScene<TImplementation, TImplementation>(null, rootContext, parent);
        }
        #endregion
    }
}