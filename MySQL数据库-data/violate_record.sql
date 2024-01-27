-- MySQL dump 10.13  Distrib 8.0.35, for Win64 (x86_64)
--
-- Host: localhost    Database: data
-- ------------------------------------------------------
-- Server version	8.0.35

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `violate_record`
--

DROP TABLE IF EXISTS `violate_record`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `violate_record` (
  `vioID` varchar(30) NOT NULL,
  `AID` varchar(30) DEFAULT NULL,
  `borrow_ID` varchar(30) DEFAULT NULL,
  `pay_date` datetime DEFAULT NULL,
  `pay_account` float DEFAULT NULL,
  `pay_state` int DEFAULT NULL,
  `statement` text,
  PRIMARY KEY (`vioID`),
  KEY `FK_Reference_11` (`AID`),
  KEY `FK_Reference_12` (`borrow_ID`),
  CONSTRAINT `FK_Reference_11` FOREIGN KEY (`AID`) REFERENCES `admin_info` (`AID`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Reference_12` FOREIGN KEY (`borrow_ID`) REFERENCES `borrow_record` (`borrow_ID`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `violate_record`
--

LOCK TABLES `violate_record` WRITE;
/*!40000 ALTER TABLE `violate_record` DISABLE KEYS */;
INSERT INTO `violate_record` VALUES ('202401251634470a1ec224-5f19-4','12130913','202401251616580a4d3815-4875-4',NULL,20,0,NULL),('20240125165403759ed8a6-baff-4','12130913','20231229170408c0c2e4dd-3eda-4',NULL,20,0,NULL);
/*!40000 ALTER TABLE `violate_record` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-01-25 21:47:38
