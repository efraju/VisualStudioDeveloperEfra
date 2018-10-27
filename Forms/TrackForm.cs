using DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class TrackForm : Form
    {
        private readonly IUnitOfWork _unitOfWork;
        public TrackForm()
        {
            _unitOfWork = new UnitOfWork(new DatabaseContext());
            InitializeComponent();
        }

        private void TrackForm_Load(object sender, EventArgs e)
        {
            // configurar los combo para mostrar la data
            cbGenre.DisplayMember = "Name";
            cbGenre.ValueMember = "GenreId";
            cbMediaType.DisplayMember = "Name";
            cbMediaType.ValueMember = "MediaTypeId";
            cbAlbum.DisplayMember = "Title";
            cbAlbum.ValueMember = "AlbumId";

            // enlazar la data
            cbGenre.DataSource = _unitOfWork.Genres.GetAll().OrderBy(g => g.Name).ToList();
            cbMediaType.DataSource = _unitOfWork.MediaTypes.GetAll().OrderBy(m => m.Name).ToList();
            cbAlbum.DataSource = _unitOfWork.Albums.GetAll().OrderBy(a => a.Title).ToList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // mapear los campos del nuevo objeto
            var newTrack = new Track
            {
                Name = txtName.Text,
                GenreId = Convert.ToInt32(cbGenre.SelectedValue),
                MediaTypeId = Convert.ToInt32(cbMediaType.SelectedValue),
                AlbumId = Convert.ToInt32(cbAlbum.SelectedValue),
                Milliseconds = Convert.ToInt32(nudMilliseconds.Value),
                UnitPrice = Convert.ToDecimal(txtUnitPrice.Text)
            };

            // insertar el nuevo objeto en BD
            _unitOfWork.Tracks.Add(newTrack);


            var mensajeResultado = _unitOfWork.Complete() > 0 ? "Success" : "Error";

            MessageBox.Show(mensajeResultado);
        }
    }
}
