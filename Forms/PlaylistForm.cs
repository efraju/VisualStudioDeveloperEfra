using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;

namespace Forms
{
    public partial class PlaylistForm : Form
    {
        private readonly IUnitOfWork _unitOfWork;
        public PlaylistForm()
        {
            InitializeComponent();
            _unitOfWork = new UnitOfWork(new DatabaseContext());
        }

        private void PlaylistForm_Load(object sender, EventArgs e)
        {
            cbPlaylists.DisplayMember = "Name";
            cbPlaylists.ValueMember = "PlaylistId";

            // enlazamos la data con el combo
            cbPlaylists.DataSource = _unitOfWork.Playlists.GetAll();
        }

        private void cbPlaylists_SelectedIndexChanged(object sender, EventArgs e)
        {
            var playlistId = Convert.ToInt32(cbPlaylists.SelectedValue);

            // obtener lista de tracks para el PL seleccionado
            var listaTracks = _unitOfWork.Tracks.GetByPlaylistId(playlistId);

            // crear un binding source para enlazar la data rápidamente
            var bindingList = new BindingList<Track>(listaTracks.ToList());
            var bindingSource = new BindingSource(bindingList, null);
            dgvTracks.DataSource = bindingSource;

        }
    }
}
