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
-- Table structure for table `book_basic_info`
--

DROP TABLE IF EXISTS `book_basic_info`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `book_basic_info` (
  `ISBN_ID` varchar(30) NOT NULL,
  `BTID` int DEFAULT NULL,
  `publish_HID` varchar(10) DEFAULT NULL,
  `BName` varchar(20) DEFAULT NULL,
  `author` varchar(20) DEFAULT NULL,
  `order_edition` int DEFAULT NULL,
  `price` float DEFAULT NULL,
  `total_count` int DEFAULT NULL,
  `left_count` int DEFAULT NULL,
  PRIMARY KEY (`ISBN_ID`),
  KEY `FK_Reference_7` (`BTID`),
  KEY `FK_Reference_8` (`publish_HID`),
  CONSTRAINT `FK_Reference_7` FOREIGN KEY (`BTID`) REFERENCES `book_type` (`BTID`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Reference_8` FOREIGN KEY (`publish_HID`) REFERENCES `publish_house_info` (`publish_HID`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `book_basic_info`
--

LOCK TABLES `book_basic_info` WRITE;
/*!40000 ALTER TABLE `book_basic_info` DISABLE KEYS */;
INSERT INTO `book_basic_info` VALUES ('100020003000',3,'100','数据库系统原理','author',6,88,30,27),('100020003300',3,'100','编译原理与实验','rose',3,66,85,84),('100020005000',3,'100','操作系统原理','author',7,75,40,38),('100020009000',3,'100','算法设计与分析','author',3,99,70,69);
/*!40000 ALTER TABLE `book_basic_info` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-01-25 21:47:37
