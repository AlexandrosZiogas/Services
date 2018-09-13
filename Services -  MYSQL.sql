/*
SQLyog Ultimate v12.09 (64 bit)
MySQL - 10.1.31-MariaDB : Database - service
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`service` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `service`;

/*Table structure for table `customers` */

DROP TABLE IF EXISTS `customers`;

CREATE TABLE `customers` (
  `customerId` int(10) NOT NULL AUTO_INCREMENT,
  `lname` varchar(50) DEFAULT NULL,
  `fname` varchar(50) DEFAULT NULL,
  `phone` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`customerId`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

/*Data for the table `customers` */

insert  into `customers`(`customerId`,`lname`,`fname`,`phone`) values (1,'Britt','Eakle','68391717'),(2,'Sheldon','Raso','69481238'),(3,'Juan','Wicker','68371236');

/*Table structure for table `details` */

DROP TABLE IF EXISTS `details`;

CREATE TABLE `details` (
  `servicesId` int(10) NOT NULL,
  `empId` int(10) unsigned NOT NULL,
  `servicedt` datetime NOT NULL,
  `notes` varchar(1000) DEFAULT NULL,
  PRIMARY KEY (`servicesId`,`empId`,`servicedt`),
  KEY `empId` (`empId`),
  CONSTRAINT `details_ibfk_1` FOREIGN KEY (`servicesId`) REFERENCES `services` (`servicesId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `details` */

insert  into `details`(`servicesId`,`empId`,`servicedt`,`notes`) values (1,1,'2018-06-22 22:07:58','Fixed'),(2,1,'2018-06-22 22:38:43','Fixed'),(2,2,'2018-06-16 22:17:50','Fixed');

/*Table structure for table `employees` */

DROP TABLE IF EXISTS `employees`;

CREATE TABLE `employees` (
  `empId` int(10) NOT NULL AUTO_INCREMENT,
  `lname` varchar(50) DEFAULT NULL,
  `fname` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`empId`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

/*Data for the table `employees` */

insert  into `employees`(`empId`,`lname`,`fname`) values (1,'Aygul','Edvard'),(2,'Leofflæd','Elias');

/*Table structure for table `services` */

DROP TABLE IF EXISTS `services`;

CREATE TABLE `services` (
  `servicesId` int(10) NOT NULL,
  `customerId` int(10) NOT NULL,
  `model` varchar(100) DEFAULT NULL,
  `indate` datetime DEFAULT NULL,
  `outdate` datetime DEFAULT NULL,
  `notesin` varchar(1000) DEFAULT NULL,
  `notesout` varchar(1000) DEFAULT NULL,
  PRIMARY KEY (`servicesId`),
  KEY `customerId` (`customerId`),
  CONSTRAINT `services_ibfk_1` FOREIGN KEY (`customerId`) REFERENCES `customers` (`customerId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `services` */

insert  into `services`(`servicesId`,`customerId`,`model`,`indate`,`outdate`,`notesin`,`notesout`) values (1,1,'Hp','2018-06-29 21:46:32','2018-06-22 21:46:35','Check','Check'),(2,2,'Toshiba','2018-06-29 22:07:35','2018-06-23 22:07:38','Check','Check');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
