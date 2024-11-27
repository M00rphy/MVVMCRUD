using Assimp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace UsersCRUD.SharpGLTests
{
    /// <summary>
    /// Interaction logic for test1.xaml
    /// </summary>
    public partial class test1 : Window
    {
        public test1()
        {
            InitializeComponent();
        }

        private void LoadModel_Click(object sender, RoutedEventArgs e)
        {
            string modelPath = "path_to_your_model/model.gltf";

            // Load model using Assimp
            var importer = new AssimpContext();
            try
            {
                var scene = importer.ImportFile(modelPath, PostProcessPreset.TargetRealTimeMaximumQuality);
                Console.WriteLine($"Model loaded with {scene.MeshCount} meshes.");

                foreach (var mesh in scene.Meshes)
                {
                    // Convert Assimp mesh to WPF mesh
                    var geometry = ConvertToMeshGeometry(mesh);

                    // Create a material for the model
                    var material = new DiffuseMaterial(new SolidColorBrush(Colors.SkyBlue));

                    // Create a 3D model
                    var model = new GeometryModel3D(geometry, material);

                    // Add the model to the viewport
                    var modelVisual = new ModelVisual3D { Content = model };
                    MainViewport.Children.Add(modelVisual);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load model: {ex.Message}");
            }
            finally
            {
                importer.Dispose();
            }
        }

        private MeshGeometry3D ConvertToMeshGeometry(Mesh mesh)
        {
            var geometry = new MeshGeometry3D();

            // Add vertices
            foreach (var vertex in mesh.Vertices)
            {
                geometry.Positions.Add(new Point3D(vertex.X, vertex.Y, vertex.Z));
            }

            // Add triangles
            foreach (var face in mesh.Faces)
            {
                if (face.IndexCount == 3) // Ensure the face is a triangle
                {
                    geometry.TriangleIndices.Add(face.Indices[0]);
                    geometry.TriangleIndices.Add(face.Indices[1]);
                    geometry.TriangleIndices.Add(face.Indices[2]);
                }
            }

            return geometry;
        }
    }
}
