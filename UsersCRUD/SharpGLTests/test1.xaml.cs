using Assimp;
using System;
using System.Collections.Generic;
using System.IO;
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
using Path = System.IO.Path;

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

            //string modelPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets\\3D\\scene.gltf");
            //C:\Users\lx\source\repos\MVVMCRUD\UsersCRUD\Assets\3D\xiaomi_mi_power_bank_3.glb


            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string modelPath = Path.Combine(projectDirectory, "Assets", "3D", "test.gltf");

            if (!File.Exists(modelPath))
            {
                MessageBox.Show($"File not found: {modelPath}");
                return;
            }


            if (!System.IO.File.Exists(modelPath))
            {
                MessageBox.Show($"File not found: {modelPath}");
                return;
            }

            var importer = new AssimpContext();
            try
            {
                var scene = importer.ImportFile(modelPath, PostProcessPreset.TargetRealTimeMaximumQuality);
                MessageBox.Show($"Model loaded with {scene.MeshCount} meshes.");

                foreach (var mesh in scene.Meshes)
                {
                    var geometry = ConvertToMeshGeometry(mesh);
                    var material = new DiffuseMaterial(new SolidColorBrush(Colors.SkyBlue));
                    var model = new GeometryModel3D(geometry, material);
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
