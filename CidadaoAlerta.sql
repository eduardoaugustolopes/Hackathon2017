/* BANCO DE DADOS PRINCIPAL */
CREATE DATABASE IF NOT EXISTS cidadaoalerta;
USE cidadaoalerta;

/* Tabela de usuários do sistema */
CREATE TABLE IF NOT EXISTS usuario(
	usuario_id integer AUTO_INCREMENT,			    /* Id do usuário */
	login varchar(50) NOT NULL DEFAULT '',	        /* Login do usuário */
	senha varchar(32) NOT NULL DEFAULT '',	        /* senha do usuário */
	CONSTRAINT cp_usuario PRIMARY KEY (usuario_id)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
