class vRegistrarLocalizacion {
    constructor() {
        this.objProvincias = [
            { idProvincia: 0, nombre: "-Seleccione una opción-" },
            { idProvincia: 1, nombre: "San José", lat: 9.9254828, lng: -84.0918343 },
            { idProvincia: 2, nombre: "Alajuela", lat: 10.014931, lng: -84.213999 },
            { idProvincia: 3, nombre: "Cartago", lat: 9.863219, lng: -83.915793 },
            { idProvincia: 4, nombre: "Heredia", lat: 9.997489, lng: -84.119668 },
            { idProvincia: 5, nombre: "Guanacaste", lat: 10.634013, lng: -85.440962 },
            { idProvincia: 6, nombre: "Puntarenas", lat: 9.977088, lng: -84.836022 },
            { idProvincia: 7, nombre: "Limón", lat: 9.990732, lng: -83.041621 }];
        this.objCantones = [//SAN JOSE
            { idCanton: 1, nombre: "San José", idProvincia: 1 },
            { idCanton: 2, nombre: "Escazú", idProvincia: 1 },
            { idCanton: 3, nombre: "Desamparados", idProvincia: 1 },
            { idCanton: 4, nombre: "Puriscal", idProvincia: 1 },
            { idCanton: 5, nombre: "Aserrí", idProvincia: 1 },
            { idCanton: 6, nombre: "Mora", idProvincia: 1 },
            { idCanton: 7, nombre: "Goicoechea", idProvincia: 1 },
            { idCanton: 8, nombre: "Santa Ana", idProvincia: 1 },
            { idCanton: 9, nombre: "Alajuelita", idProvincia: 1 },
            { idCanton: 10, nombre: "Vásquez de Coronado", idProvincia: 1 },
            { idCanton: 11, nombre: "Acosta", idProvincia: 1 },
            { idCanton: 12, nombre: "Tibás", idProvincia: 1 },
            { idCanton: 13, nombre: "Moravia", idProvincia: 1 },
            { idCanton: 14, nombre: "Montes de Oca", idProvincia: 1 },
            { idCanton: 15, nombre: "Turrubares", idProvincia: 1 },
            { idCanton: 16, nombre: "Dota", idProvincia: 1 },
            { idCanton: 17, nombre: "Curridabat", idProvincia: 1 },
            { idCanton: 18, nombre: "Pérez Zeledón", idProvincia: 1 },
            { idCanton: 19, nombre: "León Cortés Castro", idProvincia: 1 },
            { idCanton: 20, nombre: "Tarrazú", idProvincia: 1 },
            //ALAJUELA
            { idCanton: 21, nombre: "Alajuela", idProvincia: 2 },
            { idCanton: 22, nombre: "San Ramón", idProvincia: 2 },
            { idCanton: 23, nombre: "Grecia", idProvincia: 2 },
            { idCanton: 24, nombre: "San Mateo", idProvincia: 2 },
            { idCanton: 25, nombre: "Atenas", idProvincia: 2 },
            { idCanton: 26, nombre: "Naranjo", idProvincia: 2 },
            { idCanton: 27, nombre: "Palmares", idProvincia: 2 },
            { idCanton: 28, nombre: "Poás", idProvincia: 2 },
            { idCanton: 29, nombre: "Orotina", idProvincia: 2 },
            { idCanton: 30, nombre: "San Carlos", idProvincia: 2 },
            { idCanton: 31, nombre: "Zarcero", idProvincia: 2 },
            { idCanton: 32, nombre: "Sarchí", idProvincia: 2 },
            { idCanton: 33, nombre: "Upala", idProvincia: 2 },
            { idCanton: 34, nombre: "Los Chiles", idProvincia: 2 },
            { idCanton: 35, nombre: "Guatuso", idProvincia: 2 },
            { idCanton: 36, nombre: "Río Cuarto", idProvincia: 2 },
            //CARTAGO
            { idCanton: 37, nombre: "Cartago", idProvincia: 3 },
            { idCanton: 38, nombre: "Alvarado", idProvincia: 3 },
            { idCanton: 39, nombre: "El Guarco", idProvincia: 3 },
            { idCanton: 40, nombre: "Jiménez", idProvincia: 3 },
            { idCanton: 41, nombre: "La Unión", idProvincia: 3 },
            { idCanton: 42, nombre: "Paraíso", idProvincia: 3 },
            { idCanton: 43, nombre: "Turrialba", idProvincia: 3 },
            { idCanton: 44, nombre: "Oreamuno", idProvincia: 3 },
            //HEREDIA
            { idCanton: 45, nombre: "Heredia", idProvincia: 4 },
            { idCanton: 46, nombre: "San Isidro", idProvincia: 4 },
            { idCanton: 47, nombre: "San Pablo", idProvincia: 4 },
            { idCanton: 48, nombre: "San Rafael", idProvincia: 4 },
            { idCanton: 49, nombre: "Barva", idProvincia: 4 },
            { idCanton: 50, nombre: "Belén", idProvincia: 4 },
            { idCanton: 51, nombre: "Flores", idProvincia: 4 },
            { idCanton: 52, nombre: "Santo Domingo", idProvincia: 4 },
            { idCanton: 53, nombre: "Sarapiqui", idProvincia: 4 },
            { idCanton: 54, nombre: "Santa Barbara", idProvincia: 4 },
            //GUANACASTE
            { idCanton: 55, nombre: "Liberia", idProvincia: 5 },
            { idCanton: 56, nombre: "Carrillo", idProvincia: 5 },
            { idCanton: 57, nombre: "Bagaces", idProvincia: 5 },
            { idCanton: 58, nombre: "Abangares", idProvincia: 5 },
            { idCanton: 59, nombre: "Cañas", idProvincia: 5 },
            { idCanton: 60, nombre: "Hojancha", idProvincia: 5 },
            { idCanton: 61, nombre: "La Cruz", idProvincia: 5 },
            { idCanton: 62, nombre: "Nandayure", idProvincia: 5 },
            { idCanton: 63, nombre: "Santa Cruz", idProvincia: 5 },
            { idCanton: 64, nombre: "Nicoya", idProvincia: 5 },
            { idCanton: 65, nombre: "Tilaran", idProvincia: 5 },
            //PUNTARENAS
            { idCanton: 66, nombre: "Puntarenas", idProvincia: 6 },
            { idCanton: 67, nombre: "Esparza", idProvincia: 6 },
            { idCanton: 68, nombre: "Buenos Aires", idProvincia: 6 },
            { idCanton: 69, nombre: "Montes de Oro", idProvincia: 6 },
            { idCanton: 70, nombre: "Osa", idProvincia: 6 },
            { idCanton: 71, nombre: "Golfito", idProvincia: 6 },
            { idCanton: 72, nombre: "Coto Brus", idProvincia: 6 },
            { idCanton: 73, nombre: "Parrita", idProvincia: 6 },
            { idCanton: 74, nombre: "Corredores", idProvincia: 6 },
            { idCanton: 75, nombre: "Garabito", idProvincia: 6 },
            { idCanton: 76, nombre: "Quepos", idProvincia: 6 },
            //LIMON
            { idCanton: 77, nombre: "Limón", idProvincia: 7 },
            { idCanton: 78, nombre: "Pococí", idProvincia: 7 },
            { idCanton: 79, nombre: "Siquirres", idProvincia: 7 },
            { idCanton: 80, nombre: "Talamanca", idProvincia: 7 },
            { idCanton: 81, nombre: "Matina", idProvincia: 7 },
            { idCanton: 82, nombre: "Guácimo", idProvincia: 7 },
        ];
        this.objDistritos = [
            //SAN JOSE - SAN JOSE (idCanton: 1)
            { idDistrito: 1, nombre: "Carmen", idCanton: 1 },
            { idDistrito: 2, nombre: "Merced", idCanton: 1 },
            { idDistrito: 3, nombre: "Hospital", idCanton: 1 },
            { idDistrito: 4, nombre: "Catedral", idCanton: 1 },
            { idDistrito: 5, nombre: "Zapote", idCanton: 1 },
            { idDistrito: 6, nombre: "San Francisco de Dos Rios", idCanton: 1 },
            { idDistrito: 7, nombre: "Uruca", idCanton: 1 },
            { idDistrito: 8, nombre: "Mata Redonda", idCanton: 1 },
            { idDistrito: 9, nombre: "Pavas", idCanton: 1 },
            { idDistrito: 10, nombre: "Hatillo", idCanton: 1 },
            { idDistrito: 11, nombre: "San Sebastian", idCanton: 1 },
            //SAN JOSÉ - ESCAZU (idCanton: 2)
            { idDistrito: 12, nombre: "Escazu", idCanton: 2 },
            { idDistrito: 13, nombre: "San Antonio", idCanton: 2 },
            { idDistrito: 14, nombre: "San Rafael", idCanton: 2 },
            //SAN JOSÉ - DESAMPARADOS (idCanton: 3)
            { idDistrito: 15, nombre: "Desamparados", idCanton: 3 },
            { idDistrito: 16, nombre: "San Miguel", idCanton: 3 },
            { idDistrito: 17, nombre: "San Juan de Dios", idCanton: 3 },
            { idDistrito: 18, nombre: "San Rafael Arriba", idCanton: 3 },
            { idDistrito: 19, nombre: "San Antonio", idCanton: 3 },
            { idDistrito: 20, nombre: "Frailes", idCanton: 3 },
            { idDistrito: 21, nombre: "Patarra", idCanton: 3 },
            { idDistrito: 22, nombre: "San Cristobal", idCanton: 3 },
            { idDistrito: 23, nombre: "Rosario", idCanton: 3 },
            { idDistrito: 24, nombre: "Damas", idCanton: 3 },
            { idDistrito: 25, nombre: "San Rafael Abajo", idCanton: 3 },
            { idDistrito: 26, nombre: "Gravillas", idCanton: 3 },
            //SAN JOSE - PURISCAL (idCanton: 4)
            { idDistrito: 27, nombre: "Santiago", idCanton: 4 },
            { idDistrito: 28, nombre: "Mercedes Sur", idCanton: 4 },
            { idDistrito: 29, nombre: "Barbacoas", idCanton: 4 },
            { idDistrito: 30, nombre: "Grito Alto", idCanton: 4 },
            { idDistrito: 31, nombre: "San Rafael", idCanton: 4 },
            { idDistrito: 32, nombre: "Candelaria", idCanton: 4 },
            { idDistrito: 33, nombre: "Desamparaditos", idCanton: 4 },
            { idDistrito: 34, nombre: "San Antonio", idCanton: 4 },
            { idDistrito: 35, nombre: "Chires", idCanton: 4 },
            //SAN JOSE - ASERRÍ (idCanton: 5 )
            { idDistrito: 40, nombre: "Aserri", idCanton: 5 },
            { idDistrito: 41, nombre: "Tarbaca", idCanton: 5 },
            { idDistrito: 42, nombre: "Vuelta de Jorco", idCanton: 5 },
            { idDistrito: 43, nombre: "San Gabriel", idCanton: 5 },
            { idDistrito: 44, nombre: "Legua", idCanton: 5 },
            { idDistrito: 45, nombre: "Monterrey", idCanton: 5 },
            { idDistrito: 46, nombre: "Salitrillos", idCanton: 5 },
            //SAN JOSE - MORA (idCanton: 6)
            { idDistrito: 47, nombre: "Ciudad Colón", idCanton: 6 },
            { idDistrito: 48, nombre: "Guayabo", idCanton: 6 },
            { idDistrito: 49, nombre: "Tabarcia", idCanton: 6 },
            { idDistrito: 50, nombre: "Piedras Negras", idCanton: 6 },
            { idDistrito: 51, nombre: "Picagres", idCanton: 6 },
            { idDistrito: 52, nombre: "Jaris", idCanton: 6 },
            { idDistrito: 53, nombre: "Quitirrisí", idCanton: 6 },
            //SAN JOSE - GOICOCHEA (idCanton: 7)
            { idDistrito: 54, nombre: "Calle Blancos", idCanton: 7 },
            { idDistrito: 55, nombre: "Guadalupe", idCanton: 7 },
            { idDistrito: 56, nombre: "Ipis", idCanton: 7 },
            { idDistrito: 57, nombre: "Mata de Platano", idCanton: 7 },
            { idDistrito: 58, nombre: "Purral", idCanton: 7 },
            { idDistrito: 59, nombre: "Rancho Redondo", idCanton: 7 },
            { idDistrito: 60, nombre: "San Francisco", idCanton: 7 },
            //SAN JOSE - SANTA ANA (idCanton: 8)
            { idDistrito: 61, nombre: "Santa Ana", idCanton: 8 },
            { idDistrito: 62, nombre: "Salitral", idCanton: 8 },
            { idDistrito: 63, nombre: "Pozos", idCanton: 8 },
            { idDistrito: 64, nombre: "Uruca", idCanton: 8 },
            { idDistrito: 65, nombre: "Piedades", idCanton: 8 },
            { idDistrito: 66, nombre: "Brasil", idCanton: 8 },
            //SAN JOSE - ALAJUELITA (idCanton: 9)
            { idDistrito: 67, nombre: "Alajuelita", idCanton: 9 },
            { idDistrito: 68, nombre: "San Josecito", idCanton: 9 },
            { idDistrito: 69, nombre: "San Antonio", idCanton: 9 },
            { idDistrito: 70, nombre: "Concepcion", idCanton: 9 },
            { idDistrito: 71, nombre: "San Felipe", idCanton: 9 },
            //SAN JOSE - VÁSQUEZ DE CORONADO (idCanton: 10)
            { idDistrito: 72, nombre: "San Isidro", idCanton: 10 },
            { idDistrito: 73, nombre: "San Rafael", idCanton: 10 },
            { idDistrito: 74, nombre: "Jesus (Dulce Nombre)", idCanton: 10 },
            { idDistrito: 75, nombre: "Patalillo", idCanton: 10 },
            { idDistrito: 76, nombre: "Cascajal", idCanton: 10 },
            //SAN JOSE - ACOSTA (idCanton: 11)
            { idDistrito: 77, nombre: "San Ignacio", idCanton: 11 },
            { idDistrito: 78, nombre: "Guaitil", idCanton: 11 },
            { idDistrito: 79, nombre: "Palmichal", idCanton: 11 },
            { idDistrito: 80, nombre: "Cangrejal", idCanton: 11 },
            { idDistrito: 81, nombre: "Sabanillas", idCanton: 11 },
            //SAN JOSE - TIBÁS (idCanton: 12)
            { idDistrito: 82, nombre: "San Juan", idCanton: 12 },
            { idDistrito: 83, nombre: "Cinco Esquinas", idCanton: 12 },
            { idDistrito: 84, nombre: "Anselmo Llorente", idCanton: 12 },
            { idDistrito: 85, nombre: "Leon XIII", idCanton: 12 },
            { idDistrito: 86, nombre: "Colima", idCanton: 12 },
            //SAN JOSE - MORAVIA (idCanton: 13)
            { idDistrito: 87, nombre: "San Vicente", idCanton: 13 },
            { idDistrito: 88, nombre: "San Jeronimo", idCanton: 13 },
            { idDistrito: 89, nombre: "Trinidad", idCanton: 13 },
            //SAN JOSE - MONTES DE OCA (idCanton: 14)
            { idDistrito: 90, nombre: "San Pedro", idCanton: 14 },
            { idDistrito: 91, nombre: "Sabanilla", idCanton: 14 },
            { idDistrito: 92, nombre: "Mercedes(Betania)", idCanton: 14 },
            { idDistrito: 93, nombre: "San Rafael", idCanton: 14 },
            //SAN JOSE - TURRUBARES (idCanton: 15)
            { idDistrito: 94, nombre: "San Pablo", idCanton: 15 },
            { idDistrito: 95, nombre: "San Pedro", idCanton: 15 },
            { idDistrito: 96, nombre: "San Juan de Mata", idCanton: 15 },
            { idDistrito: 97, nombre: "San Luis", idCanton: 15 },
            { idDistrito: 98, nombre: "Carara", idCanton: 15 },
            //SAN JOSE - DOTA (idCanton: 16)
            { idDistrito: 99, nombre: "Santa Maria", idCanton: 16 },
            { idDistrito: 100, nombre: "Jardín", idCanton: 16 },
            { idDistrito: 101, nombre: "Copey", idCanton: 16 },
            //SAN JOSE - CURRIDABAT (idCanton: 17)
            { idDistrito: 102, nombre: "Curridabat", idCanton: 17 },
            { idDistrito: 103, nombre: "Granadilla", idCanton: 17 },
            { idDistrito: 104, nombre: "Sanchez", idCanton: 17 },
            { idDistrito: 105, nombre: "Tirrases", idCanton: 17 },
            //SAN JOSE - PÉREZ ZELEDÓN (idCanton: 18)
            { idDistrito: 106, nombre: "San Isidro del General", idCanton: 18 },
            { idDistrito: 107, nombre: "General", idCanton: 18 },
            { idDistrito: 108, nombre: "Daniel Flores", idCanton: 18 },
            { idDistrito: 109, nombre: "Rivas", idCanton: 18 },
            { idDistrito: 110, nombre: "San Pedro", idCanton: 18 },
            { idDistrito: 111, nombre: "Platanares", idCanton: 18 },
            { idDistrito: 112, nombre: "Pejibaye", idCanton: 18 },
            { idDistrito: 113, nombre: "Cajón", idCanton: 18 },
            { idDistrito: 114, nombre: "Barú", idCanton: 18 },
            { idDistrito: 115, nombre: "Rio Nuevo", idCanton: 18 },
            { idDistrito: 116, nombre: "Páramo", idCanton: 18 },
            { idDistrito: 117, nombre: "La Amistad", idCanton: 18 },
            //SAN JOSE - LEÓN CORTEZ (idCanton: 19)
            { idDistrito: 118, nombre: "San Pablo", idCanton: 19 },
            { idDistrito: 119, nombre: "San Andrés", idCanton: 19 },
            { idDistrito: 120, nombre: "Llano Bonito", idCanton: 19 },
            { idDistrito: 121, nombre: "San Isidro", idCanton: 19 },
            { idDistrito: 122, nombre: "Santa Cruz", idCanton: 19 },
            { idDistrito: 123, nombre: "San Antonio", idCanton: 19 },
            //SAN JOSE - TARRAZÚ (idCanton: 20)
            { idDistrito: 124, nombre: "San Marcos", idCanton: 20 },
            { idDistrito: 125, nombre: "San Lorenzo", idCanton: 20 },
            { idDistrito: 126, nombre: "San Carlos", idCanton: 20 },
            //ALAJUELA - ALAJUELA (idCanton: 21)
            { idDistrito: 127, nombre: "Alajuela", idCanton: 21 },
            { idDistrito: 128, nombre: "Carrizal", idCanton: 21 },
            { idDistrito: 129, nombre: "San Antonio", idCanton: 21 },
            { idDistrito: 130, nombre: "Guacima", idCanton: 21 },
            { idDistrito: 131, nombre: "San Isidro", idCanton: 21 },
            { idDistrito: 132, nombre: "Sabanilla", idCanton: 21 },
            { idDistrito: 133, nombre: "San Rafael", idCanton: 21 },
            { idDistrito: 134, nombre: "Rio Segundo", idCanton: 21 },
            { idDistrito: 135, nombre: "Desamparados", idCanton: 21 },
            { idDistrito: 136, nombre: "Turrucares", idCanton: 21 },
            { idDistrito: 137, nombre: "Tambor", idCanton: 21 },
            { idDistrito: 138, nombre: "Garita", idCanton: 21 },
            { idDistrito: 139, nombre: "Sarapiqui", idCanton: 21 },
            //ALAJUELA - SAN RAMÓN (idCanton: 22)
            { idDistrito: 140, nombre: "San Ramon", idCanton: 22 },
            { idDistrito: 141, nombre: "Santiago", idCanton: 22 },
            { idDistrito: 142, nombre: "San Juan", idCanton: 22 },
            { idDistrito: 143, nombre: "Piedades Norte", idCanton: 22 },
            { idDistrito: 144, nombre: "Piedades Sur", idCanton: 22 },
            { idDistrito: 145, nombre: "San Rafael", idCanton: 22 },
            { idDistrito: 146, nombre: "San Isidro", idCanton: 22 },
            { idDistrito: 147, nombre: "Ángeles", idCanton: 22 },
            { idDistrito: 148, nombre: "Alfaro", idCanton: 22 },
            { idDistrito: 149, nombre: "Volio", idCanton: 22 },
            { idDistrito: 150, nombre: "Concepción", idCanton: 22 },
            { idDistrito: 151, nombre: "Zapotal", idCanton: 22 },
            { idDistrito: 152, nombre: "Peñas Blancas", idCanton: 22 },
            { idDistrito: 153, nombre: "San Lorenzo", idCanton: 22 },
            //ALAJUELA - GRECIA (idCanton: 23)
            { idDistrito: 154, nombre: "Grecia", idCanton: 23 },
            { idDistrito: 155, nombre: "San Isidro", idCanton: 23 },
            { idDistrito: 156, nombre: "San José", idCanton: 23 },
            { idDistrito: 157, nombre: "San Roque", idCanton: 23 },
            { idDistrito: 158, nombre: "Tacares", idCanton: 23 },
            { idDistrito: 159, nombre: "Rio Cuarto", idCanton: 23 },
            { idDistrito: 160, nombre: "Puente de Piedra", idCanton: 23 },
            { idDistrito: 161, nombre: "Bolivar", idCanton: 23 },
            //ALAJUELA - SAN MATEO (idCanton: 24)
            { idDistrito: 162, nombre: "San Mateo", idCanton: 24 },
            { idDistrito: 163, nombre: "Desmonte", idCanton: 24 },
            { idDistrito: 164, nombre: "Jesus Maria", idCanton: 24 },
            { idDistrito: 165, nombre: "Labrador", idCanton: 24 },
            //ALAJUELA - ATENAS (idCanton: 25)
            { idDistrito: 166, nombre: "Atenas", idCanton: 25 },
            { idDistrito: 167, nombre: "Jesús", idCanton: 25 },
            { idDistrito: 168, nombre: "Mercedes", idCanton: 25 },
            { idDistrito: 169, nombre: "San Isidro", idCanton: 25 },
            { idDistrito: 170, nombre: "Concepción", idCanton: 25 },
            { idDistrito: 171, nombre: "San José", idCanton: 25 },
            { idDistrito: 172, nombre: "Santa Eulalia", idCanton: 25 },
            { idDistrito: 173, nombre: "Escobal", idCanton: 25 },
            //ALAJUELA - NARANJO (idCanton: 26)
            { idDistrito: 174, nombre: "Naranjo", idCanton: 26 },
            { idDistrito: 175, nombre: "San Miguel", idCanton: 26 },
            { idDistrito: 176, nombre: "Cirrí Sur", idCanton: 26 },
            { idDistrito: 177, nombre: "San Jerónimo", idCanton: 26 },
            { idDistrito: 178, nombre: "San Juan", idCanton: 26 },
            { idDistrito: 179, nombre: "El Rosario", idCanton: 26 },
            { idDistrito: 180, nombre: "Palmitos", idCanton: 26 },
            //ALAJUELA - PALMARES (idCanton: 27)
            { idDistrito: 181, nombre: "Palmares", idCanton: 27 },
            { idDistrito: 182, nombre: "Zaragoza", idCanton: 27 },
            { idDistrito: 183, nombre: "Buenos Aires", idCanton: 27 },
            { idDistrito: 184, nombre: "Santiago", idCanton: 27 },
            { idDistrito: 185, nombre: "Candelaria", idCanton: 27 },
            { idDistrito: 186, nombre: "Esquipulas", idCanton: 27 },
            { idDistrito: 187, nombre: "La Granja", idCanton: 27 },
            //ALAJUELA - POÁS (idCanton: 28)
            { idDistrito: 188, nombre: "San Pedro", idCanton: 28 },
            { idDistrito: 189, nombre: "San Juan", idCanton: 28 },
            { idDistrito: 190, nombre: "San Rafael", idCanton: 28 },
            { idDistrito: 191, nombre: "Carrillos", idCanton: 28 },
            { idDistrito: 192, nombre: "Sabana Redonda", idCanton: 28 },
            //ALAJUELA - OROTINA (idCanton: 29)
            { idDistrito: 193, nombre: "Orotina", idCanton: 29 },
            { idDistrito: 194, nombre: "Mastate", idCanton: 29 },
            { idDistrito: 195, nombre: "Hacienda Vieja", idCanton: 29 },
            { idDistrito: 196, nombre: "Coyolar", idCanton: 29 },
            { idDistrito: 197, nombre: "La Ceiba", idCanton: 29 },
            //ALAJUELA - SAN CARLOS (idCanton: 30)
            { idDistrito: 198, nombre: "Quesada", idCanton: 30 },
            { idDistrito: 199, nombre: "Florencia", idCanton: 30 },
            { idDistrito: 200, nombre: "Buenavista", idCanton: 30 },
            { idDistrito: 201, nombre: "Aguas Zarcas", idCanton: 30 },
            { idDistrito: 202, nombre: "Venecia", idCanton: 30 },
            { idDistrito: 203, nombre: "Pital", idCanton: 30 },
            { idDistrito: 204, nombre: "La Fortuna", idCanton: 30 },
            { idDistrito: 205, nombre: "La Tigra", idCanton: 30 },
            { idDistrito: 206, nombre: "La Palmera", idCanton: 30 },
            { idDistrito: 207, nombre: "Venado", idCanton: 30 },
            { idDistrito: 208, nombre: "Cutris", idCanton: 30 },
            { idDistrito: 209, nombre: "Monterrey", idCanton: 30 },
            { idDistrito: 210, nombre: "Pocosol", idCanton: 30 },
            //ALAJUELA - ZARCERO (idCanton: 31)
            { idDistrito: 211, nombre: "Zarcero", idCanton: 31 },
            { idDistrito: 212, nombre: "Laguna", idCanton: 31 },
            { idDistrito: 213, nombre: "Tapezco", idCanton: 31 },
            { idDistrito: 214, nombre: "Guadalupe", idCanton: 31 },
            { idDistrito: 215, nombre: "Palmira", idCanton: 31 },
            { idDistrito: 216, nombre: "Zapote", idCanton: 31 },
            { idDistrito: 217, nombre: "Brisas", idCanton: 31 },
            //ALAJUELA - SARCHÍ (idCanton: 32)
            { idDistrito: 218, nombre: "Sarchí Norte", idCanton: 32 },
            { idDistrito: 219, nombre: "Sarchí Sur", idCanton: 32 },
            { idDistrito: 220, nombre: "Toro Amarillo", idCanton: 32 },
            { idDistrito: 221, nombre: "San Pedro", idCanton: 32 },
            { idDistrito: 222, nombre: "Rodríguez", idCanton: 32 },
            //ALAJUELA - UPALA (idCanton: 33)
            { idDistrito: 223, nombre: "Upala", idCanton: 33 },
            { idDistrito: 224, nombre: "Aguas Claras", idCanton: 33 },
            { idDistrito: 225, nombre: "San José (Pizote)", idCanton: 33 },
            { idDistrito: 226, nombre: "Bijagua", idCanton: 33 },
            { idDistrito: 227, nombre: "Delicias", idCanton: 33 },
            { idDistrito: 228, nombre: "Dos Rios (Colonia Mayorga)", idCanton: 33 },
            { idDistrito: 229, nombre: "Yolillal", idCanton: 33 },
            //ALAJUELA - LOS CHILES (idCanton: 34)
            { idDistrito: 230, nombre: "Los Chiles", idCanton: 34 },
            { idDistrito: 231, nombre: "Caño Negro", idCanton: 34 },
            { idDistrito: 232, nombre: "El Amparo", idCanton: 34 },
            { idDistrito: 233, nombre: "San Jorge", idCanton: 34 },
            //ALAJUELA - GUATUSO (idCanton: 35)
            { idDistrito: 234, nombre: "San Rafael", idCanton: 35 },
            { idDistrito: 235, nombre: "Buenavista", idCanton: 35 },
            { idDistrito: 236, nombre: "Cote", idCanton: 35 },
            { idDistrito: 237, nombre: "Katira", idCanton: 35 },
            //ALAJUELA - RÍO CUARTO (idCanton: 36)
            { idDistrito: 238, nombre: "Río Cuarto", idCanton: 36 },
            { idDistrito: 239, nombre: "Santa Isabel", idCanton: 36 },
            { idDistrito: 240, nombre: "Santa Rita", idCanton: 36 },
            //CARTAGO - CARTAGO (idCanton: 37)
            { idDistrito: 241, nombre: "Oriental", idCanton: 37 },
            { idDistrito: 242, nombre: "Occidental", idCanton: 37 },
            { idDistrito: 243, nombre: "Carmen", idCanton: 37 },
            { idDistrito: 244, nombre: "San Nicolás", idCanton: 37 },
            { idDistrito: 245, nombre: "Agua Caliente", idCanton: 37 },
            { idDistrito: 246, nombre: "Guadalupe", idCanton: 37 },
            { idDistrito: 247, nombre: "Corralillo", idCanton: 37 },
            { idDistrito: 248, nombre: "Tierra Blanca", idCanton: 37 },
            { idDistrito: 249, nombre: "Dulce Nombre", idCanton: 37 },
            { idDistrito: 250, nombre: "Llano Grande", idCanton: 37 },
            { idDistrito: 251, nombre: "Quebradilla", idCanton: 37 },
            //CARTAGO - ALVARADO (idCanton: 38)
            { idDistrito: 252, nombre: "Pacayas", idCanton: 38 },
            { idDistrito: 253, nombre: "Cervantes", idCanton: 38 },
            { idDistrito: 254, nombre: "Capellades", idCanton: 38 },
            //CARTAGO - EL GUARCO (idCanton: 39)
            { idDistrito: 255, nombre: "El Tejar", idCanton: 39 },
            { idDistrito: 256, nombre: "San Isidro", idCanton: 39 },
            { idDistrito: 257, nombre: "Tobosi", idCanton: 39 },
            { idDistrito: 258, nombre: "Patio de Agua", idCanton: 39 },
            //CARTAGO - JIMENEZ (idCanton: 40)
            { idDistrito: 259, nombre: "Juan Viñas", idCanton: 40 },
            { idDistrito: 260, nombre: "Tucurrique", idCanton: 40 },
            { idDistrito: 261, nombre: "Pejibaye", idCanton: 40 },
            //CARTAGO - LA UNIÓN (idCanton: 41)
            { idDistrito: 262, nombre: "Tres Rios", idCanton: 41 },
            { idDistrito: 263, nombre: "San Diego", idCanton: 41 },
            { idDistrito: 264, nombre: "San Juan", idCanton: 41 },
            { idDistrito: 265, nombre: "San Rafael", idCanton: 41 },
            { idDistrito: 266, nombre: "Concepción", idCanton: 41 },
            { idDistrito: 267, nombre: "Dulce Nombre", idCanton: 41 },
            { idDistrito: 268, nombre: "San Ramón", idCanton: 41 },
            { idDistrito: 269, nombre: "Río Azul", idCanton: 41 },
            //CARTAGO - PARAÍSO (idCanton: 42)
            { idDistrito: 270, nombre: "Paraíso", idCanton: 42 },
            { idDistrito: 271, nombre: "Santiago", idCanton: 42 },
            { idDistrito: 272, nombre: "Orosi", idCanton: 42 },
            { idDistrito: 273, nombre: "Cachí", idCanton: 42 },
            { idDistrito: 274, nombre: "Llanos de Santa Lucía", idCanton: 42 },
            //CARTAGO - TURRIALBA (idCanton: 43)
            { idDistrito: 275, nombre: "Turrialba", idCanton: 43 },
            { idDistrito: 276, nombre: "La Suiza", idCanton: 43 },
            { idDistrito: 277, nombre: "Peralta", idCanton: 43 },
            { idDistrito: 278, nombre: "Santa cruz", idCanton: 43 },
            { idDistrito: 279, nombre: "Santa Teresita", idCanton: 43 },
            { idDistrito: 280, nombre: "Pavones", idCanton: 43 },
            { idDistrito: 281, nombre: "Tuis", idCanton: 43 },
            { idDistrito: 282, nombre: "Tayutic", idCanton: 43 },
            { idDistrito: 283, nombre: "Santa Rosa", idCanton: 43 },
            { idDistrito: 284, nombre: "Tres Equis", idCanton: 43 },
            { idDistrito: 285, nombre: "La Isabel", idCanton: 43 },
            { idDistrito: 286, nombre: "Chirripó", idCanton: 43 },
            //CARTAGO - OREAMUNO (idCanton: 44)
            { idDistrito: 287, nombre: "San Rafael", idCanton: 44 },
            { idDistrito: 288, nombre: "Cot", idCanton: 44 },
            { idDistrito: 289, nombre: "Potrero Cerrado", idCanton: 44 },
            { idDistrito: 290, nombre: "Cipreses", idCanton: 44 },
            { idDistrito: 291, nombre: "Santa Rosa", idCanton: 44 },
            //HEREDIA - HEREDIA (idCanton: 45)***
            { idDistrito: 292, nombre: "Heredia", idCanton: 45 },
            { idDistrito: 293, nombre: "Mercedes", idCanton: 45 },
            { idDistrito: 294, nombre: "San Francisco", idCanton: 45 },
            { idDistrito: 295, nombre: "Ulloa", idCanton: 45 },
            { idDistrito: 296, nombre: "Varablanca", idCanton: 45 },
            //HEREDIA - SAN ISIDRIO (idCanton: 46)
            { idDistrito: 297, nombre: "San Isidro", idCanton: 46 },
            { idDistrito: 298, nombre: "San José", idCanton: 46 },
            { idDistrito: 299, nombre: "Concepción", idCanton: 46 },
            { idDistrito: 300, nombre: "San Francisco", idCanton: 46 },
            //HEREDIA - SAN PABLO (idCanton: 47)
            { idDistrito: 301, nombre: "San Pablo", idCanton: 47 },
            { idDistrito: 302, nombre: "Rincón de Sabanilla", idCanton: 47 },
            //HEREDIA - SAN RAFAEL (idCanton: 48)
            { idDistrito: 303, nombre: "San Rafael", idCanton: 48 },
            { idDistrito: 304, nombre: "San Josecito", idCanton: 48 },
            { idDistrito: 305, nombre: "Santiago", idCanton: 48 },
            { idDistrito: 306, nombre: "Ángeles", idCanton: 48 },
            { idDistrito: 307, nombre: "Concepción", idCanton: 48 },
            //HEREDIA - BARVA (idCanton: 49)
            { idDistrito: 308, nombre: "Barva", idCanton: 49 },
            { idDistrito: 309, nombre: "San Pedro", idCanton: 49 },
            { idDistrito: 310, nombre: "San Pablo", idCanton: 49 },
            { idDistrito: 311, nombre: "San Roque", idCanton: 49 },
            { idDistrito: 312, nombre: "Santa Lucia", idCanton: 49 },
            { idDistrito: 313, nombre: "San José la Montaña", idCanton: 49 },
            //HEREDIA - BELÉN (idCanton: 50)
            { idDistrito: 314, nombre: "San Antonio", idCanton: 50 },
            { idDistrito: 315, nombre: "La Ribera", idCanton: 50 },
            { idDistrito: 316, nombre: "Asunción", idCanton: 50 },
            //HEREDIA - FLORES (idCanton: 51)
            { idDistrito: 317, nombre: "San Joaquin de Flores", idCanton: 51 },
            { idDistrito: 318, nombre: "Barrantes", idCanton: 51 },
            { idDistrito: 319, nombre: "Llorente", idCanton: 51 },
            //HEREDIA - SANTO DOMINGO (idCanton: 52)
            { idDistrito: 320, nombre: "Santo Domingo", idCanton: 52 },
            { idDistrito: 321, nombre: "San Vicente", idCanton: 52 },
            { idDistrito: 322, nombre: "San Miguel", idCanton: 52 },
            { idDistrito: 323, nombre: "Paracito", idCanton: 52 },
            { idDistrito: 324, nombre: "Santo Tomas", idCanton: 52 },
            { idDistrito: 325, nombre: "Santa Rosa", idCanton: 52 },
            { idDistrito: 326, nombre: "Tures", idCanton: 52 },
            { idDistrito: 327, nombre: "Pará", idCanton: 52 },
            //HEREDIA - SARAPIQUI (idCanton: 53)
            { idDistrito: 328, nombre: "Puerto Viejo", idCanton: 53 },
            { idDistrito: 329, nombre: "La Virgen", idCanton: 53 },
            { idDistrito: 330, nombre: "Horquetas", idCanton: 53 },
            { idDistrito: 331, nombre: "Llanuras del Gaspar", idCanton: 53 },
            { idDistrito: 332, nombre: "Cureña", idCanton: 53 },
            //HEREDIA - SANTA BARBARA(idCanton: 54)
            { idDistrito: 333, nombre: "Santa Barbara", idCanton: 54 },
            { idDistrito: 334, nombre: "San Pedro", idCanton: 54 },
            { idDistrito: 335, nombre: "San Juan", idCanton: 54 },
            { idDistrito: 336, nombre: "Jesus", idCanton: 54 },
            { idDistrito: 337, nombre: "Santo Domingo", idCanton: 54 },
            { idDistrito: 338, nombre: "Purabá", idCanton: 54 },
            //GUANACASTE - LIBERIA (idCanton: 55)
            { idDistrito: 339, nombre: "Liberia", idCanton: 53 },
            { idDistrito: 340, nombre: "Cañas Dulces", idCanton: 53 },
            { idDistrito: 341, nombre: "Mayorga", idCanton: 53 },
            { idDistrito: 342, nombre: "Nacascolo", idCanton: 53 },
            { idDistrito: 343, nombre: "Curubandé", idCanton: 53 },
            //GUANACASTE - CARRILLO (idCanton: 56)
            { idDistrito: 344, nombre: "Filadelfia", idCanton: 56 },
            { idDistrito: 345, nombre: "Palmira", idCanton: 56 },
            { idDistrito: 346, nombre: "Sardinal", idCanton: 56 },
            { idDistrito: 347, nombre: "Belén", idCanton: 56 },
            //GUANACASTE - BAGACES (idCanton: 57)
            { idDistrito: 348, nombre: "Bagaces", idCanton: 57 },
            { idDistrito: 349, nombre: "La Fortuna", idCanton: 57 },
            { idDistrito: 350, nombre: "Mogote", idCanton: 57 },
            { idDistrito: 351, nombre: "Río Naranjo", idCanton: 57 },
            //GUANACASTE - ABANGARES (idCanton: 58)
            { idDistrito: 352, nombre: "Las Juntas", idCanton: 58 },
            { idDistrito: 353, nombre: "Sierra", idCanton: 58 },
            { idDistrito: 354, nombre: "San Juan", idCanton: 58 },
            { idDistrito: 355, nombre: "Colorado", idCanton: 58 },
            //GUANACASTE - CAÑAS (idCanton: 59)
            { idDistrito: 356, nombre: "Cañas", idCanton: 59 },
            { idDistrito: 357, nombre: "Palmira", idCanton: 59 },
            { idDistrito: 358, nombre: "San Miguel", idCanton: 59 },
            { idDistrito: 359, nombre: "Bebedero", idCanton: 59 },
            { idDistrito: 360, nombre: "Porozal", idCanton: 59 },
            //GUANACASTE - HOJANCHA (idCanton: 60)
            { idDistrito: 361, nombre: "Hojancha", idCanton: 60 },
            { idDistrito: 362, nombre: "Monte Romo", idCanton: 60 },
            { idDistrito: 363, nombre: "Puerto Carrillo", idCanton: 60 },
            { idDistrito: 364, nombre: "Huacas", idCanton: 60 },
            { idDistrito: 365, nombre: "Matambú", idCanton: 60 },
            //GUANACASTE - LA CRUZ (idCanton: 61)
            { idDistrito: 366, nombre: "La Cruz", idCanton: 61 },
            { idDistrito: 367, nombre: "Santa Cecilia", idCanton: 61 },
            { idDistrito: 368, nombre: "La Garita", idCanton: 61 },
            { idDistrito: 369, nombre: "Santa Elena", idCanton: 61 },
            //GUANACASTE - NANDAYURE (idCanton: 62)
            { idDistrito: 370, nombre: "Carmona", idCanton: 62 },
            { idDistrito: 371, nombre: "Santa Rita", idCanton: 62 },
            { idDistrito: 372, nombre: "Zapotal", idCanton: 62 },
            { idDistrito: 373, nombre: "San Pablo", idCanton: 62 },
            { idDistrito: 374, nombre: "Porvenir", idCanton: 62 },
            { idDistrito: 375, nombre: "Bejuco", idCanton: 62 },
            //GUANACASTE - SANTA CRUZ (idCanton: 63)
            { idDistrito: 376, nombre: "Santa Cruz", idCanton: 63 },
            { idDistrito: 377, nombre: "Bolsón", idCanton: 63 },
            { idDistrito: 378, nombre: "Veintisiete de Abril", idCanton: 63 },
            { idDistrito: 379, nombre: "Tempate", idCanton: 63 },
            { idDistrito: 380, nombre: "Cartagena", idCanton: 63 },
            { idDistrito: 381, nombre: "Coajiniquil", idCanton: 63 },
            { idDistrito: 382, nombre: "Diriá", idCanton: 63 },
            { idDistrito: 383, nombre: "Cabo Velas", idCanton: 63 },
            { idDistrito: 384, nombre: "Tamarindo", idCanton: 63 },
            //GUANACASTE - NICOYA (idCanton: 64)
            { idDistrito: 385, nombre: "Nicoya", idCanton: 64 },
            { idDistrito: 386, nombre: "Mansión", idCanton: 64 },
            { idDistrito: 387, nombre: "San Antonio", idCanton: 64 },
            { idDistrito: 388, nombre: "Quebrada Honda", idCanton: 64 },
            { idDistrito: 389, nombre: "Samara", idCanton: 64 },
            { idDistrito: 390, nombre: "Nosara", idCanton: 64 },
            { idDistrito: 391, nombre: "Belen de Nosarita", idCanton: 64 },
            //GUANACASTE - TILARAN (idCanton: 65)
            { idDistrito: 392, nombre: "Tilarán", idCanton: 65 },
            { idDistrito: 393, nombre: "Quebrada Grande", idCanton: 65 },
            { idDistrito: 394, nombre: "Tronadora", idCanton: 65 },
            { idDistrito: 395, nombre: "Santa Rosa", idCanton: 65 },
            { idDistrito: 396, nombre: "Libano", idCanton: 65 },
            { idDistrito: 397, nombre: "Tierras Morenas", idCanton: 65 },
            { idDistrito: 398, nombre: "Arenal", idCanton: 65 },
            //PUNTARENAS - PUNTARENAS (idCanton: 66)
            { idDistrito: 399, nombre: "Puntarenas", idCanton: 66 },
            { idDistrito: 400, nombre: "Pitahaya", idCanton: 66 },
            { idDistrito: 401, nombre: "Chomes", idCanton: 66 },
            { idDistrito: 402, nombre: "Lepanto", idCanton: 66 },
            { idDistrito: 403, nombre: "Paquera", idCanton: 66 },
            { idDistrito: 404, nombre: "Manzanillo", idCanton: 66 },
            { idDistrito: 405, nombre: "Guacimal", idCanton: 66 },
            { idDistrito: 406, nombre: "Barranca", idCanton: 66 },
            { idDistrito: 407, nombre: "Monte Verde", idCanton: 66 },
            { idDistrito: 408, nombre: "Isla del Coco", idCanton: 66 },
            { idDistrito: 409, nombre: "Cóbano", idCanton: 66 },
            { idDistrito: 410, nombre: "Chacarita", idCanton: 66 },
            { idDistrito: 411, nombre: "Chira", idCanton: 66 },
            { idDistrito: 412, nombre: "Acapulco", idCanton: 66 },
            { idDistrito: 413, nombre: "El Roble", idCanton: 66 },
            { idDistrito: 414, nombre: "Arancibia", idCanton: 66 },
            //PUNTARENAS - ESPARZA (idCanton: 67)
            { idDistrito: 415, nombre: "Espíritu Santo", idCanton: 67 },
            { idDistrito: 416, nombre: "San Juan Grande", idCanton: 67 },
            { idDistrito: 417, nombre: "Macacona", idCanton: 67 },
            { idDistrito: 418, nombre: "San Rafael", idCanton: 67 },
            { idDistrito: 419, nombre: "San Jerónimo", idCanton: 67 },
            { idDistrito: 420, nombre: "Buenos Aires", idCanton: 67 },
            { idDistrito: 421, nombre: "Caldera", idCanton: 67 },
            //PUNTARENAS - BUENOS AIRES (idCanton: 68)
            { idDistrito: 422, nombre: "Buenos Aires", idCanton: 68 },
            { idDistrito: 423, nombre: "Volcán", idCanton: 68 },
            { idDistrito: 424, nombre: "Potrero Grande", idCanton: 68 },
            { idDistrito: 425, nombre: "Boruca", idCanton: 68 },
            { idDistrito: 426, nombre: "Pilas", idCanton: 68 },
            { idDistrito: 427, nombre: "Colinas", idCanton: 68 },
            { idDistrito: 428, nombre: "Chánguena", idCanton: 68 },
            { idDistrito: 429, nombre: "Biolley", idCanton: 68 },
            { idDistrito: 430, nombre: "Brunka", idCanton: 68 },
            //PUNTARENAS - MONTES DE ORO (idCanton: 69)
            { idDistrito: 431, nombre: "Miramar", idCanton: 69 },
            { idDistrito: 432, nombre: "Union", idCanton: 69 },
            { idDistrito: 433, nombre: "San Isidro", idCanton: 68 },
            //PUNTARENAS - OSA (idCanton: 70)
            { idDistrito: 434, nombre: "Ciudad Cortés", idCanton: 70 },
            { idDistrito: 435, nombre: "Palmar", idCanton: 70 },
            { idDistrito: 436, nombre: "Sierpe", idCanton: 70 },
            { idDistrito: 437, nombre: "Bahía Ballena", idCanton: 70 },
            { idDistrito: 438, nombre: "Piedras Blancas", idCanton: 70 },
            { idDistrito: 439, nombre: "Bahía Drake", idCanton: 70 },
            //PUNTARENAS - GOLFITO (idCanton: 71)
            { idDistrito: 440, nombre: "Golfito", idCanton: 71 },
            { idDistrito: 441, nombre: "Puerto Jiménez", idCanton: 71 },
            { idDistrito: 442, nombre: "Guaycará", idCanton: 71 },
            { idDistrito: 443, nombre: "Pavón", idCanton: 71 },
            //PUNTARENAS - COTO BRUS (idCanton: 72)
            { idDistrito: 444, nombre: "San Vito", idCanton: 72 },
            { idDistrito: 445, nombre: "Sabalito", idCanton: 72 },
            { idDistrito: 446, nombre: "Aguabuena", idCanton: 72 },
            { idDistrito: 447, nombre: "Limoncito", idCanton: 72 },
            { idDistrito: 448, nombre: "Pittier", idCanton: 72 },
            { idDistrito: 449, nombre: "Gutiérrez Brown", idCanton: 72 },
            //PUNTARENAS - PARRITA (idCanton: 73)
            { idDistrito: 450, nombre: "Parrita", idCanton: 73 },
            //PUNTARENAS - CORREDORES (idCanton: 74)
            { idDistrito: 451, nombre: "Corredor", idCanton: 74 },
            { idDistrito: 452, nombre: "La Cuesta", idCanton: 74 },
            { idDistrito: 453, nombre: "Paso Canoas", idCanton: 74 },
            { idDistrito: 454, nombre: "Laurel", idCanton: 74 },
            //PUNTARENAS - GARABITO (idCanton: 75)
            { idDistrito: 455, nombre: "Jacó", idCanton: 75 },
            { idDistrito: 456, nombre: "Tarcoles", idCanton: 75 },
            //PUNTARENAS - QUEPOS (idCanton: 76)
            { idDistrito: 457, nombre: "Quepos", idCanton: 76 },
            { idDistrito: 458, nombre: "Savegre", idCanton: 76 },
            { idDistrito: 459, nombre: "Naranjito", idCanton: 76 },
            //LIMON - LIMON (idCanton: 77)
            { idDistrito: 440, nombre: "Limón", idCanton: 77 },
            { idDistrito: 441, nombre: "Valle la Estrella", idCanton: 77 },
            { idDistrito: 442, nombre: "Río Blanco", idCanton: 77 },
            { idDistrito: 443, nombre: "Matama", idCanton: 77 },
            //LIMON - POCOCI (idCanton: 78)
            { idDistrito: 444, nombre: "Guápiles", idCanton: 78 },
            { idDistrito: 445, nombre: "Jiménez", idCanton: 78 },
            { idDistrito: 446, nombre: "La Rita", idCanton: 78 },
            { idDistrito: 447, nombre: "Roxana", idCanton: 78 },
            { idDistrito: 448, nombre: "Cariari", idCanton: 78 },
            { idDistrito: 449, nombre: "Colorado", idCanton: 78 },
            { idDistrito: 449, nombre: "La Colonia", idCanton: 78 },
            //LIMON - SIQUIRRES (idCanton: 79)
            { idDistrito: 450, nombre: "Siquirres", idCanton: 78 },
            { idDistrito: 451, nombre: "Pacuarito", idCanton: 78 },
            { idDistrito: 452, nombre: "Florida", idCanton: 78 },
            { idDistrito: 453, nombre: "Germania", idCanton: 78 },
            { idDistrito: 454, nombre: "Cairo", idCanton: 78 },
            { idDistrito: 455, nombre: "Alegría", idCanton: 78 },
            //LIMON - TALAMANCA (idCanton: 80)
            { idDistrito: 456, nombre: "Bratsi", idCanton: 80 },
            { idDistrito: 457, nombre: "Sixaola", idCanton: 80 },
            { idDistrito: 458, nombre: "Cahuita", idCanton: 80 },
            { idDistrito: 458, nombre: "Telire", idCanton: 80 },
            //LIMON - MATINA (idCanton: 81)
            { idDistrito: 459, nombre: "Matina", idCanton: 79 },
            { idDistrito: 460, nombre: "Batán", idCanton: 79 },
            { idDistrito: 461, nombre: "Carrandi", idCanton: 79 },
            //LIMON - GUACIMO (idCanton: 82)
            { idDistrito: 462, nombre: "Guácimo", idCanton: 82 },
            { idDistrito: 463, nombre: "Mercedes", idCanton: 82 },
            { idDistrito: 464, nombre: "Pocora", idCanton: 82 },
            { idDistrito: 465, nombre: "Río Jimenez", idCanton: 82 },
            { idDistrito: 466, nombre: "Duacarí", idCanton: 82 },
        ];
        this.sltProvincias = document.querySelector('#sltProvincias');
        this.sltCantones = document.querySelector('#sltCantones');
        this.sltDistritos = document.querySelector('#sltDistritos');

        this.btnRegistrar = document.getElementById('btnCrear');

        this.ctrlActions = new ControlActions();
        this.fillsltProvincia();
        mapboxgl.accessToken = 'pk.eyJ1IjoiYXVyZW9zb2Z0IiwiYSI6ImNrOHI4MG9oeDAydngzbW14d2pyemJxZngifQ.7Oe29pjYO56R3BJJ3vyjpw';
        this.map = new mapboxgl.Map({
            container: 'map',
            style: 'mapbox://styles/mapbox/streets-v11',
            center: [-84.0918343, 9.9254828], zoom: 12
        });
        this.map.addControl(new mapboxgl.NavigationControl());
        $("#txtLongitud").attr('disabled', 'disabled');
        $("#txtLatitud").attr('disabled', 'disabled');
        this.desactivarBtn();
        $('#btnCerrar').hide();
    }

    get formInputs() {
        const inputs = Array.from(document.querySelectorAll('.required'), (input) => {
            const inputData = {
                isValid: input.validity.valid,
                element: input,
                small: input.nextElementSibling
            }
            return inputData;
        });
        return inputs;
    }
    fillsltProvincia() {
        for (const provincia of this.objProvincias) {
            this.sltProvincias.options.add(new Option(provincia.nombre, provincia.idProvincia));
        }
        this.sltCantones.innerHTML = "";
        this.sltDistritos.innerHTML = "";
        this.sltCantones.options.add(new Option("-Seleccione una opción-", 0));
        this.sltDistritos.options.add(new Option("-Seleccione una opción-", 0));
    }
    llenarCantones(cantones) {
        this.sltCantones.innerHTML = "";
        this.sltDistritos.innerHTML = "";
        this.sltCantones.options.add(new Option("-Seleccione una opción-", 0));
        this.sltDistritos.options.add(new Option("-Seleccione una opción-", 0));
        for (const c of cantones) {
            this.sltCantones.options.add(new Option(c.nombre, c.idCanton));
        }
    }

    llenarDistritos(distritos) {
        sltDistritos.innerHTML = "";

        sltDistritos.options.add(new Option("-Seleccione una opción-", 0));
        for (const d of distritos) {
            sltDistritos.options.add(new Option(d.nombre, d.idDistrito));
        }
    }

    desactivarBtn() {
        this.btnRegistrar.classList.add('disabled');
        this.btnRegistrar.disabled = true;
    }

    activarBtn() {
        this.btnRegistrar.classList.remove('disabled');
        this.btnRegistrar.removeAttribute('disabled');
    }

    validateForm() {
        let valido = true;
        for (const dataKey in this.formInputs) {
            if (this.formInputs.hasOwnProperty(dataKey)) {
                const currentData = this.formInputs[dataKey];
                if (currentData.isValid === false) {
                    valido = false;
                    currentData.element.classList.add('is-invalid');
                    currentData.small.classList.remove('text-muted');
                    currentData.small.classList.add('invalid-feedback');
                } else {
                    if (currentData.element.value === '0') {
                        valido = false;
                        currentData.element.classList.add('is-invalid');
                        currentData.small.classList.remove('text-muted');
                        currentData.small.classList.remove('d-none');
                        currentData.small.classList.add('invalid-feedback');
                    } else {
                        currentData.element.classList.remove('is-invalid');
                        currentData.element.classList.add('is-valid');
                        currentData.small.classList.remove('text-muted');
                        currentData.small.classList.remove('invalid-feedback');
                        currentData.small.classList.add('d-none');
                    }
                }
            }
        }
        if (valido === true) {
            this.activarBtn();
        } else {
            this.desactivarBtn();
        }
    }

    getValuesForm() {
        const localizacionData = this.ctrlActions.GetDataForm('frmCreate');
        localizacionData.Provincia = this.obtenerProvinciaId(localizacionData.Provincia);
        localizacionData.Canton = this.obtenerCantonId(localizacionData.Canton);
        localizacionData.Distrito = this.obtenerDistritoId(localizacionData.Distrito);
        localizacionData.IdUsuario = sessionStorage.getItem('CedulaRegistro');
        this.ctrlActions.PostToAPI('Localizacion', localizacionData);
        this.clearForm();
        this.validarAccionSiguiente();
    }

    obtenerProvinciaId(id) {
        let pid = parseInt(id);
        let nombreProvincia;
        for (const provincia of this.objProvincias) {
            if (provincia.idProvincia === pid) {
                nombreProvincia = provincia.nombre;
            }
        }
        return nombreProvincia;
    }

    obtenerCantonId(id) {
        let pid = parseInt(id);
        let nombreCanton;
        for (const canton of this.objCantones) {
            if (canton.idCanton === pid) {
                nombreCanton = canton.nombre;
            }
        }
        return nombreCanton;
    }

    obtenerDistritoId(id) {
        let pid = parseInt(id);
        let nombreDistrito;
        for (const distrito of this.objDistritos) {
            if (distrito.idDistrito === pid) {
                nombreDistrito = distrito.nombre;
            }
        }
        return nombreDistrito;
    }

    validarAccionSiguiente() {
        const tipoRegistro = sessionStorage.getItem('TipoRegistro');

        if (tipoRegistro === 'Cliente') {
            $("#registrarContrasenna").modal();

        } else {
            $("#ready").modal();

        }
    }
    clearForm() {
        const inputs = Array.from(document.querySelectorAll('.form-control'), (input) => {
            input.value = '';
            input.classList.remove('is-valid');
            return input;
        });
        this.fillsltProvincia();
    }

    llenarUbicacion(map) {

        const longitud = document.getElementById('txtLongitud');
        const latitud = document.getElementById('txtLatitud');
        longitud.value = this.position[0];
        latitud.value = this.position[1];
    }

    redireccionarCliente() {
        sessionStorage.removeItem('CedulaRegistro');
        sessionStorage.removeItem('TipoRegistro');
        window.location.href = 'http://localhost:61102';
    }

    redireccionarOferente() {
        sessionStorage.removeItem('CedulaRegistro');
        window.location.href = 'http://localhost:61102';
    }

    crearEventos() {
        document.addEventListener('keyup', () => { this.validateForm() });
        this.sltProvincias.addEventListener('change', (e) => {
            var idp = e.target.value;
            const cantones = this.objCantones.filter(canton => canton.idProvincia === parseInt(idp));
            this.llenarCantones(cantones);
        });

        this.sltCantones.addEventListener('change', (e) => {
            var idc = e.target.value;
            const distritos = this.objDistritos.filter(distrito => distrito.idCanton === parseInt(idc));
            this.llenarDistritos(distritos);
        });

        this.sltProvincias.addEventListener('change', () => { this.validateForm() });
        this.sltCantones.addEventListener('change', () => { this.validateForm() });
        this.sltDistritos.addEventListener('change', () => { this.validateForm() });
        this.btnRegistrar.addEventListener('click', () => { this.getValuesForm() });

        this.map.on('click', (mapa) => {
            this.position = [mapa.lngLat.lng, mapa.lngLat.lat];
            this.llenarUbicacion(this.position)
        });

        const btn = document.getElementById('envio');
        btn.addEventListener('click', () => { this.redireccionarOferente() });

        const btnCliente = document.getElementById('cliente');
        btnCliente.addEventListener('click', () => { this.redireccionarCliente() });
    }
}

document.addEventListener("DOMContentLoaded", function (event) {
    const controller = new vRegistrarLocalizacion();
    controller.crearEventos();
});
