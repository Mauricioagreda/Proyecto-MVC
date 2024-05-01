create database Musica;
use Musica;

create table Artista(idArtista int primary key not null,
					 nombre varchar(50) not null);

create table ALbum(idAlbum int primary key not null,
				   idArtista int not null,
                   constraint fk_Album_Artista foreign key(idArtista) references Artista(idArtista),
				   nombre varchar(50) not null);
                   
create table Cancion(idCancion int primary key not null,
					 idAlbum int not null,
                     constraint fk_Cancion_Album foreign key(idAlbum) references Album(idAlbum),
                     nombre varchar(50) not null);



