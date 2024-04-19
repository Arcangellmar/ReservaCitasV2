-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         11.4.0-MariaDB - mariadb.org binary distribution
-- SO del servidor:              Win64
-- HeidiSQL Versión:             12.3.0.6589
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Volcando estructura de base de datos para reserva_citas
DROP DATABASE IF EXISTS `reserva_citas`;
CREATE DATABASE IF NOT EXISTS `reserva_citas` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci */;
USE `reserva_citas`;

-- Volcando estructura para procedimiento reserva_citas.SP_ACCOUNT_LOGIN
DROP PROCEDURE IF EXISTS `SP_ACCOUNT_LOGIN`;
DELIMITER //
CREATE PROCEDURE `SP_ACCOUNT_LOGIN`(
	IN `PARAM_VC_DNI` VARCHAR(50),
	IN `PARAM_VC_PASSWORD` VARCHAR(50)
)
BEGIN

	SELECT
		ID_PACIENTE,
		VC_DNI,
		VC_PASS,
		CH_SITUACION_REGISTRO
	FROM ta_paciente
	WHERE
		VC_DNI = PARAM_VC_DNI
		AND VC_PASS = PARAM_VC_PASSWORD;
		
END//
DELIMITER ;

-- Volcando estructura para procedimiento reserva_citas.SP_DOCTOR_LISTAR
DROP PROCEDURE IF EXISTS `SP_DOCTOR_LISTAR`;
DELIMITER //
CREATE PROCEDURE `SP_DOCTOR_LISTAR`()
BEGIN

	SELECT
		D.ID_DOCTOR,
		D.VC_NOMBRE,
		D.IN_ID_ESPECIALIDAD,
		E.VC_NOMRBE AS NOMBRE_ESPECIALIDAD
	FROM ta_doctor D
		LEFT JOIN ta_especialidad E
			ON D.IN_ID_ESPECIALIDAD = E.ID_ESPECIALIDAD
	WHERE
		D.CH_SITUACION_REGISTRO = "A";

END//
DELIMITER ;

-- Volcando estructura para procedimiento reserva_citas.SP_ESPECIALIDAD_LISTAR
DROP PROCEDURE IF EXISTS `SP_ESPECIALIDAD_LISTAR`;
DELIMITER //
CREATE PROCEDURE `SP_ESPECIALIDAD_LISTAR`()
BEGIN
	
	SELECT
		ID_ESPECIALIDAD,
		VC_NOMRBE
	FROM ta_especialidad
	WHERE CH_SITUACION_REGISTRO = "A";

END//
DELIMITER ;

-- Volcando estructura para procedimiento reserva_citas.SP_USUARIO_OBTENER
DROP PROCEDURE IF EXISTS `SP_USUARIO_OBTENER`;
DELIMITER //
CREATE PROCEDURE `SP_USUARIO_OBTENER`(
	IN `PARAM_ID_USUARIO` INT
)
BEGIN

	SELECT
		P.ID_PACIENTE,
		P.VC_NOMBRE,
		P.VC_EDAD,
		P.VC_SEXO,
		S.NOMBRE AS VC_SEGURO,
		P.VC_PESO,
		P.VC_ALTURA,
		P.VC_DNI,
		P.VC_PASS
	FROM ta_paciente P
	LEFT JOIN ta_seguro S
		ON P.IN_ID_SEGURO = S.ID_SEGURO
	WHERE P.ID_PACIENTE = PARAM_ID_USUARIO;

END//
DELIMITER ;

-- Volcando estructura para tabla reserva_citas.ta_citas
DROP TABLE IF EXISTS `ta_citas`;
CREATE TABLE IF NOT EXISTS `ta_citas` (
  `ID_CITA` int(11) NOT NULL AUTO_INCREMENT,
  `IN_ID_DOCTOR` int(11) DEFAULT NULL,
  `IN_ID_PACIENTE` int(11) DEFAULT NULL,
  `IN_ID_LOCAL` int(11) DEFAULT NULL,
  `DT_FECHA` date DEFAULT NULL,
  `CH_SITUACION_REGISTRO` char(1) DEFAULT NULL,
  PRIMARY KEY (`ID_CITA`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla reserva_citas.ta_doctor
DROP TABLE IF EXISTS `ta_doctor`;
CREATE TABLE IF NOT EXISTS `ta_doctor` (
  `ID_DOCTOR` int(11) NOT NULL AUTO_INCREMENT,
  `VC_NOMBRE` varchar(50) DEFAULT NULL,
  `IN_ID_ESPECIALIDAD` int(11) DEFAULT NULL,
  `CH_SITUACION_REGISTRO` char(1) DEFAULT NULL,
  PRIMARY KEY (`ID_DOCTOR`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla reserva_citas.ta_especialidad
DROP TABLE IF EXISTS `ta_especialidad`;
CREATE TABLE IF NOT EXISTS `ta_especialidad` (
  `ID_ESPECIALIDAD` int(11) NOT NULL AUTO_INCREMENT,
  `VC_NOMRBE` varchar(50) DEFAULT NULL,
  `CH_SITUACION_REGISTRO` char(1) DEFAULT NULL,
  PRIMARY KEY (`ID_ESPECIALIDAD`)
) ENGINE=InnoDB AUTO_INCREMENT=54 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla reserva_citas.ta_local
DROP TABLE IF EXISTS `ta_local`;
CREATE TABLE IF NOT EXISTS `ta_local` (
  `ID_LOCAL` int(11) NOT NULL AUTO_INCREMENT,
  `VC_NOIMBRE` varchar(50) DEFAULT NULL,
  `VC_DIRECCION` varchar(50) DEFAULT NULL,
  `CH_SITUACION_REGISTRO` char(1) DEFAULT NULL,
  PRIMARY KEY (`ID_LOCAL`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla reserva_citas.ta_paciente
DROP TABLE IF EXISTS `ta_paciente`;
CREATE TABLE IF NOT EXISTS `ta_paciente` (
  `ID_PACIENTE` int(11) NOT NULL AUTO_INCREMENT,
  `VC_NOMBRE` varchar(50) DEFAULT NULL,
  `VC_EDAD` varchar(50) DEFAULT NULL,
  `VC_SEXO` varchar(50) DEFAULT NULL,
  `IN_ID_SEGURO` int(11) DEFAULT NULL,
  `VC_PESO` varchar(50) DEFAULT NULL,
  `VC_ALTURA` varchar(50) DEFAULT NULL,
  `VC_DNI` varchar(50) DEFAULT NULL,
  `VC_PASS` varchar(50) DEFAULT NULL,
  `CH_SITUACION_REGISTRO` char(1) DEFAULT NULL,
  PRIMARY KEY (`ID_PACIENTE`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla reserva_citas.ta_seguro
DROP TABLE IF EXISTS `ta_seguro`;
CREATE TABLE IF NOT EXISTS `ta_seguro` (
  `ID_SEGURO` int(11) NOT NULL AUTO_INCREMENT,
  `NOMBRE` varchar(50) DEFAULT NULL,
  `CH_SITUACION_REGISTRO` char(1) DEFAULT NULL,
  PRIMARY KEY (`ID_SEGURO`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- La exportación de datos fue deseleccionada.

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
