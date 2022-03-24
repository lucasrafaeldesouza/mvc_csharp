using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using Models;

namespace Views
{
   public class AtualizarDentista : Form //Atualizar Dentista
    {
        private System.ComponentModel.IContainer components = null;

        Label lblNome;
        Label lblCpf;
        Label lblNascimento;
        Label lblTelefone;
        Label lblEmail;
        Label lblSenha;
        Label lblId;

        TextBox txtNome;
        TextBox txtCpf;
        DateTimePicker dtpNascimento;
        TextBox txtTelefone;
        TextBox txtEmail;
        TextBox txtSenha;
        TextBox txtId;

        Button btnConfirm;
        Button btnCancel;

        public AtualizarDentista()
        {
            this.lblNome = new Label();
            this.lblNome.Text = "Nome";
            this.lblNome.Location = new Point(132, 20);

            this.lblCpf = new Label();
            this.lblCpf.Text = "CPF";
            this.lblCpf.Location = new Point(135, 80);
            this.lblCpf.Size = new Size(300, 30);

            this.lblTelefone = new Label();
            this.lblTelefone.Text = "Telefone";
            this.lblTelefone.Location = new Point(132, 140);
            this.lblTelefone.Size = new Size(300, 30);

            this.lblEmail = new Label();
            this.lblEmail.Text = "Email";
            this.lblEmail.Location = new Point(130, 200);
            this.lblEmail.Size = new Size(300, 30);

            this.lblSenha = new Label();
            this.lblSenha.Text = "Senha";
            this.lblSenha.Location = new Point(130, 260);
            this.lblSenha.Size = new Size(300, 30);

            this.lblNascimento = new Label();
            this.lblNascimento.Text = "Data de Nascimento";
            this.lblNascimento.Location = new Point(95, 320);
            this.lblNascimento.Size = new Size(300, 30);

            this.lblId = new Label();
            this.lblId.Text = "ID de Alteração";
            this.lblId.Location = new Point(110, 380);
            this.lblId.Size = new Size(300, 30);

            this.txtNome = new TextBox();
            this.txtNome.Location = new Point(10, 50);
            this.txtNome.Size = new Size(280, 30);

            this.txtCpf = new TextBox();
            this.txtCpf.Location = new Point(10, 110);
            this.txtCpf.Size = new Size(280, 30);

            this.txtTelefone = new TextBox();
            this.txtTelefone.Location = new Point(10, 170);
            this.txtTelefone.Size = new Size(280, 30);

            this.txtEmail = new TextBox();
            this.txtEmail.Location = new Point(10, 230);
            this.txtEmail.Size = new Size(280, 30);

            this.txtSenha = new TextBox();
            this.txtSenha.Location = new Point(10, 290);
            this.txtSenha.Size = new Size(280, 30);

            this.dtpNascimento = new DateTimePicker();
            this.dtpNascimento.Location = new Point(10, 350);
            this.dtpNascimento.Size = new Size(280, 30);

            this.txtId = new TextBox();
            this.txtId.Location = new Point(10, 410);
            this.txtId.Size = new Size(280, 30);

            this.btnConfirm = new Button();
            this.btnConfirm.Text = "Confirmar";
            this.btnConfirm.Location = new Point(70, 460);
            this.btnConfirm.Size = new Size(80, 30);
            this.btnConfirm.Click += new EventHandler(this.handleConfirmClick);

            this.btnCancel = new Button();
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.Location = new Point(160, 460);
            this.btnCancel.Size = new Size(80, 30);
            this.btnCancel.Click += new EventHandler(this.handleCancelClick);

            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lblCpf);
            this.Controls.Add(this.lblNascimento);
            this.Controls.Add(this.lblTelefone);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.lblId);

            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtCpf);
            this.Controls.Add(this.dtpNascimento);
            this.Controls.Add(this.txtTelefone);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.txtId);

            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Text = "Atualizar Paciente ";
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void handleConfirmClick(object sender, EventArgs e)
        {

        }

        private void handleCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}