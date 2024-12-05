using System;
using System.IO;
using System.Windows;
using HelixToolkit.Wpf.SharpDX;
using HelixToolkit.SharpDX.Core;
using HelixToolkit.SharpDX.Core.Model.Scene;
using HelixToolkit.SharpDX.Core.Loader;
using SharpDX;
using HelixToolkit.Wpf;

namespace UsersCRUD
{
    public partial class test1 : Window
    {
        private SceneNode modelScene;

        public test1()
        {
            InitializeComponent();
        }

        private void LoadModel_Click(object sender, RoutedEventArgs e)
        {
            // Model path
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string modelPath = Path.Combine(projectDirectory, "Assets", "3D", "test.gltf");

            try
            {
                // Load the GLTF model using GLTFLoader
                var loader = new Importer();
                var scene = loader.Load(modelPath);

                // Attach the model to the viewport
                ModelContainer.Items.Clear();
                if (scene != null)
                {
                    foreach (var node in scene.Root.Traverse())
                    {
                        if (node is MeshNode meshNode)
                        {
                            ModelContainer.Items.Add(meshNode);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Failed to load model: Scene is null.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading model: {ex.Message}");
            }
        }

        private void RotateCamera_Click(object sender, RoutedEventArgs e)
        {
            if (helixViewport.Camera is PerspectiveCamera camera)
            {
                camera.Position = new System.Windows.Media.Media3D.Point3D(
                    camera.Position.X + 5, camera.Position.Y, camera.Position.Z);
            }
        }
    }
}
