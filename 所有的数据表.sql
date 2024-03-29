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
-- Table structure for table `admin_info`
--

DROP TABLE IF EXISTS `admin_info`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `admin_info` (
  `AID` varchar(10) NOT NULL,
  `AName` varchar(30) DEFAULT NULL,
  `sex` int DEFAULT NULL,
  `contact` varchar(20) DEFAULT NULL,
  `post` varchar(30) DEFAULT NULL,
  `password` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`AID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `admin_info`
--

LOCK TABLES `admin_info` WRITE;
/*!40000 ALTER TABLE `admin_info` DISABLE KEYS */;
INSERT INTO `admin_info` VALUES ('12130913','大陈',0,'13323353333','没有','666'),('12172230','仁兄',0,'719287635','abc.com','777'),('12172231','旁白',0,'12768598789','jkl.oi','888');
/*!40000 ALTER TABLE `admin_info` ENABLE KEYS */;
UNLOCK TABLES;

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

--
-- Table structure for table `book_collect_info`
--

DROP TABLE IF EXISTS `book_collect_info`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `book_collect_info` (
  `BCID` varchar(30) NOT NULL,
  `ISBN_ID` varchar(30) DEFAULT NULL,
  `Bstate` int DEFAULT NULL,
  `BCtime` datetime DEFAULT NULL,
  PRIMARY KEY (`BCID`),
  KEY `FK_Reference_6` (`ISBN_ID`),
  CONSTRAINT `FK_Reference_6` FOREIGN KEY (`ISBN_ID`) REFERENCES `book_basic_info` (`ISBN_ID`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `book_collect_info`
--

LOCK TABLES `book_collect_info` WRITE;
/*!40000 ALTER TABLE `book_collect_info` DISABLE KEYS */;
INSERT INTO `book_collect_info` VALUES ('2023121716132007ccda00-f434-4','100020003000',0,'2023-12-17 00:00:00'),('202312171613201dda5161-5241-4','100020003000',1,'2023-12-17 00:00:00'),('2023121716132022d8cbae-f3d1-4','100020003000',0,'2023-12-17 00:00:00'),('2023121716132030333f7b-e4ba-4','100020003000',0,'2023-12-17 00:00:00'),('202312171613203105a2a6-b40a-4','100020003000',1,'2023-12-17 00:00:00'),('2023121716132032110dbb-e7f2-4','100020003000',1,'2023-12-17 00:00:00'),('202312171613205cb0ead2-2945-4','100020003000',0,'2023-12-17 00:00:00'),('202312171613206998a815-1e3b-4','100020003000',0,'2023-12-17 00:00:00'),('202312171613206c3f4cc0-3282-4','100020003000',0,'2023-12-17 00:00:00'),('20231217161320756b9e3c-32f6-4','100020003000',0,'2023-12-17 00:00:00'),('202312171613207c6bf577-3473-4','100020003000',0,'2023-12-17 00:00:00'),('20231217161320853a3bbd-dbac-4','100020003000',0,'2023-12-17 00:00:00'),('202312171613208fa765ae-acd2-4','100020003000',0,'2023-12-17 00:00:00'),('20231217161320936560fd-3051-4','100020003000',0,'2023-12-17 00:00:00'),('2023121716132098b9eb27-ec42-4','100020003000',0,'2023-12-17 00:00:00'),('202312171613209dbbedf1-6b51-4','100020003000',0,'2023-12-17 00:00:00'),('20231217161320aa062242-2961-4','100020003000',0,'2023-12-17 00:00:00'),('20231217161320aae5e765-5ba3-4','100020003000',0,'2023-12-17 00:00:00'),('20231217161320b7b81721-da1b-4','100020003000',0,'2023-12-17 00:00:00'),('20231217161320bba704a2-fb6e-4','100020003000',0,'2023-12-17 00:00:00'),('20231217161320c2eb98f5-1694-4','100020003000',0,'2023-12-17 00:00:00'),('20231217161320c4555872-d3bb-4','100020003000',0,'2023-12-17 00:00:00'),('20231217161320c78282c6-abe3-4','100020003000',0,'2023-12-17 00:00:00'),('20231217161320cff26ef0-6fd0-4','100020003000',0,'2023-12-17 00:00:00'),('20231217161320d1848098-2b6b-4','100020003000',0,'2023-12-17 00:00:00'),('20231217161320d9168041-a07a-4','100020003000',0,'2023-12-17 00:00:00'),('20231217161320dfbf17e6-51a8-4','100020003000',0,'2023-12-17 00:00:00'),('20231217161320e78a9771-e960-4','100020003000',0,'2023-12-17 00:00:00'),('20231217161320e7bebc7b-b005-4','100020003000',0,'2023-12-17 00:00:00'),('20231217161320f12b39ae-6378-4','100020003000',0,'2023-12-17 00:00:00'),('202312171616110054e2a3-e423-4','100020005000',1,'2023-12-17 00:00:00'),('202312171616110a51853a-0b8f-4','100020005000',0,'2023-12-17 00:00:00'),('202312171616110acc004b-9208-4','100020005000',1,'2023-12-17 00:00:00'),('2023121716161110fa2e57-9b1e-4','100020005000',0,'2023-12-17 00:00:00'),('2023121716161111d6cd3d-788e-4','100020005000',0,'2023-12-17 00:00:00'),('202312171616111c83679b-3038-4','100020005000',0,'2023-12-17 00:00:00'),('202312171616111d1e27e8-ce77-4','100020005000',0,'2023-12-17 00:00:00'),('20231217161611227044ba-2225-4','100020005000',0,'2023-12-17 00:00:00'),('202312171616112e25378f-e90e-4','100020005000',0,'2023-12-17 00:00:00'),('2023121716161136260feb-4396-4','100020005000',0,'2023-12-17 00:00:00'),('202312171616113fa6be49-f84a-4','100020005000',0,'2023-12-17 00:00:00'),('2023121716161143a91d6c-0fb6-4','100020005000',0,'2023-12-17 00:00:00'),('202312171616114832b820-2874-4','100020005000',0,'2023-12-17 00:00:00'),('202312171616114c1f26af-28c7-4','100020005000',0,'2023-12-17 00:00:00'),('202312171616114e5c2d2c-819c-4','100020005000',0,'2023-12-17 00:00:00'),('202312171616114f98e6e6-8274-4','100020005000',0,'2023-12-17 00:00:00'),('202312171616115e416335-c1ac-4','100020005000',0,'2023-12-17 00:00:00'),('2023121716161171b30564-1ec9-4','100020005000',0,'2023-12-17 00:00:00'),('2023121716161174aee8fe-5e31-4','100020005000',0,'2023-12-17 00:00:00'),('20231217161611794bd184-9477-4','100020005000',0,'2023-12-17 00:00:00'),('202312171616117d61c076-57d3-4','100020005000',0,'2023-12-17 00:00:00'),('202312171616117e695619-06ad-4','100020005000',0,'2023-12-17 00:00:00'),('202312171616117f95a56f-fbbb-4','100020005000',0,'2023-12-17 00:00:00'),('2023121716161187729c67-7e0e-4','100020005000',0,'2023-12-17 00:00:00'),('2023121716161192cbe92b-bd82-4','100020005000',0,'2023-12-17 00:00:00'),('202312171616119af9bc83-9ec5-4','100020005000',0,'2023-12-17 00:00:00'),('202312171616119d65a889-8d94-4','100020005000',0,'2023-12-17 00:00:00'),('20231217161611a478aada-27fa-4','100020005000',0,'2023-12-17 00:00:00'),('20231217161611a873db89-0cd7-4','100020005000',0,'2023-12-17 00:00:00'),('20231217161611ada1ca19-6040-4','100020005000',0,'2023-12-17 00:00:00'),('20231217161611b1f7cd99-c2bb-4','100020005000',0,'2023-12-17 00:00:00'),('20231217161611b9f21fc3-57c7-4','100020005000',0,'2023-12-17 00:00:00'),('20231217161611c0ccc183-3d0b-4','100020005000',0,'2023-12-17 00:00:00'),('20231217161611c45158c2-be84-4','100020005000',0,'2023-12-17 00:00:00'),('20231217161611c8818afe-e7b0-4','100020005000',0,'2023-12-17 00:00:00'),('20231217161611ca92f7ea-3e69-4','100020005000',0,'2023-12-17 00:00:00'),('20231217161611d29c4d57-c202-4','100020005000',0,'2023-12-17 00:00:00'),('20231217161611f34dd104-2d04-4','100020005000',0,'2023-12-17 00:00:00'),('20231217161611f8cb3c73-7c9b-4','100020005000',0,'2023-12-17 00:00:00'),('20231217161611fea52ede-adfd-4','100020005000',0,'2023-12-17 00:00:00'),('20231229170301007ba1c6-031a-4','100020009000',0,'2023-12-29 00:00:00'),('20231229170301032abf3e-a805-4','100020009000',1,'2023-12-29 00:00:00'),('20231229170301051c2860-7296-4','100020009000',0,'2023-12-29 00:00:00'),('2023122917030105990b8f-c651-4','100020009000',0,'2023-12-29 00:00:00'),('20231229170301069279b1-39d3-4','100020009000',0,'2023-12-29 00:00:00'),('202312291703010bfa7440-21a2-4','100020009000',0,'2023-12-29 00:00:00'),('20231229170301132f7a91-f83c-4','100020009000',0,'2023-12-29 00:00:00'),('202312291703011330caec-99c2-4','100020009000',0,'2023-12-29 00:00:00'),('2023122917030116a37966-7c58-4','100020009000',0,'2023-12-29 00:00:00'),('2023122917030119ddada6-4496-4','100020009000',0,'2023-12-29 00:00:00'),('202312291703011b66b863-8264-4','100020009000',0,'2023-12-29 00:00:00'),('202312291703011c6163a8-2c4a-4','100020009000',0,'2023-12-29 00:00:00'),('202312291703011d85198b-a081-4','100020009000',0,'2023-12-29 00:00:00'),('202312291703011e67982d-dc6f-4','100020009000',0,'2023-12-29 00:00:00'),('2023122917030121a0e016-1351-4','100020009000',0,'2023-12-29 00:00:00'),('20231229170301273288f2-e879-4','100020009000',0,'2023-12-29 00:00:00'),('202312291703012b9ba2c2-5e07-4','100020009000',0,'2023-12-29 00:00:00'),('2023122917030130ea5743-bd8a-4','100020009000',0,'2023-12-29 00:00:00'),('202312291703013580441f-725e-4','100020009000',0,'2023-12-29 00:00:00'),('2023122917030139f00927-1919-4','100020009000',0,'2023-12-29 00:00:00'),('202312291703013b978d47-b7ce-4','100020009000',0,'2023-12-29 00:00:00'),('202312291703013edc9eaa-8dbe-4','100020009000',0,'2023-12-29 00:00:00'),('20231229170301480547ea-1911-4','100020009000',0,'2023-12-29 00:00:00'),('2023122917030148850461-e359-4','100020009000',0,'2023-12-29 00:00:00'),('202312291703014b1391c9-cfce-4','100020009000',0,'2023-12-29 00:00:00'),('202312291703014c186239-5e47-4','100020009000',0,'2023-12-29 00:00:00'),('202312291703014cf84242-a18d-4','100020009000',0,'2023-12-29 00:00:00'),('202312291703015171de9e-b4e7-4','100020009000',0,'2023-12-29 00:00:00'),('20231229170301577b81b1-5fc7-4','100020009000',0,'2023-12-29 00:00:00'),('202312291703015e260702-d871-4','100020009000',0,'2023-12-29 00:00:00'),('202312291703015ea311a6-d7d3-4','100020009000',0,'2023-12-29 00:00:00'),('202312291703015fcaa4c8-b596-4','100020009000',0,'2023-12-29 00:00:00'),('20231229170301606cd0f4-d4af-4','100020009000',0,'2023-12-29 00:00:00'),('20231229170301663e813a-ebee-4','100020009000',0,'2023-12-29 00:00:00'),('202312291703016c5a7118-3641-4','100020009000',0,'2023-12-29 00:00:00'),('202312291703016ca32744-83c5-4','100020009000',0,'2023-12-29 00:00:00'),('20231229170301709c3d9e-261e-4','100020009000',0,'2023-12-29 00:00:00'),('202312291703017cf9025d-4c61-4','100020009000',0,'2023-12-29 00:00:00'),('20231229170301809b8bac-f21d-4','100020009000',0,'2023-12-29 00:00:00'),('2023122917030184a12f5d-21e3-4','100020009000',0,'2023-12-29 00:00:00'),('202312291703018622d4ab-145d-4','100020009000',0,'2023-12-29 00:00:00'),('20231229170301880ccec2-9d68-4','100020009000',0,'2023-12-29 00:00:00'),('202312291703018aed3d85-5fd7-4','100020009000',0,'2023-12-29 00:00:00'),('202312291703018d1bfb68-abbd-4','100020009000',0,'2023-12-29 00:00:00'),('202312291703018fd82f91-0917-4','100020009000',0,'2023-12-29 00:00:00'),('202312291703019a9e4151-fe7a-4','100020009000',0,'2023-12-29 00:00:00'),('202312291703019b021c34-e419-4','100020009000',0,'2023-12-29 00:00:00'),('202312291703019b996062-991a-4','100020009000',0,'2023-12-29 00:00:00'),('202312291703019f827247-d970-4','100020009000',0,'2023-12-29 00:00:00'),('202312291703019fccef49-5dcf-4','100020009000',0,'2023-12-29 00:00:00'),('20231229170301a80ae764-5713-4','100020009000',0,'2023-12-29 00:00:00'),('20231229170301ad814688-16fe-4','100020009000',0,'2023-12-29 00:00:00'),('20231229170301aeb6923c-a99d-4','100020009000',0,'2023-12-29 00:00:00'),('20231229170301af1c4a06-2208-4','100020009000',0,'2023-12-29 00:00:00'),('20231229170301b310ac71-351e-4','100020009000',0,'2023-12-29 00:00:00'),('20231229170301b48a4754-6643-4','100020009000',0,'2023-12-29 00:00:00'),('20231229170301bdbaa6e5-8c29-4','100020009000',0,'2023-12-29 00:00:00'),('20231229170301c085e188-5529-4','100020009000',0,'2023-12-29 00:00:00'),('20231229170301c198ff4a-2521-4','100020009000',0,'2023-12-29 00:00:00'),('20231229170301c45f82ab-9025-4','100020009000',0,'2023-12-29 00:00:00'),('20231229170301c615bd7c-d010-4','100020009000',0,'2023-12-29 00:00:00'),('20231229170301ccb5b415-256f-4','100020009000',0,'2023-12-29 00:00:00'),('20231229170301d66d4e46-8e97-4','100020009000',0,'2023-12-29 00:00:00'),('20231229170301d701c9ee-46d2-4','100020009000',0,'2023-12-29 00:00:00'),('20231229170301d72ddd96-d24a-4','100020009000',0,'2023-12-29 00:00:00'),('20231229170301da1461b5-485f-4','100020009000',0,'2023-12-29 00:00:00'),('20231229170301dd17866c-5664-4','100020009000',0,'2023-12-29 00:00:00'),('20231229170301e4402134-517e-4','100020009000',0,'2023-12-29 00:00:00'),('20231229170301ea322f42-f9c1-4','100020009000',0,'2023-12-29 00:00:00'),('20231229170301fd8f6b94-1eec-4','100020009000',0,'2023-12-29 00:00:00'),('20231229171745ca5059af-054a-4','100020003300',1,'2023-12-29 00:00:00'),('2023122917174600a266af-a90f-4','100020003300',0,'2023-12-29 00:00:00'),('202312291717460225e4e5-2d4c-4','100020003300',0,'2023-12-29 00:00:00'),('20231229171746093283fd-d4dd-4','100020003300',0,'2023-12-29 00:00:00'),('202312291717460bb50770-73cf-4','100020003300',0,'2023-12-29 00:00:00'),('202312291717460c8c5d02-ca06-4','100020003300',0,'2023-12-29 00:00:00'),('202312291717460faa2fdb-3ec7-4','100020003300',0,'2023-12-29 00:00:00'),('202312291717460faa571f-32ad-4','100020003300',0,'2023-12-29 00:00:00'),('2023122917174612c3d7ee-39c1-4','100020003300',0,'2023-12-29 00:00:00'),('2023122917174612e5fe5b-bfaa-4','100020003300',0,'2023-12-29 00:00:00'),('20231229171746141a3b29-a8a4-4','100020003300',0,'2023-12-29 00:00:00'),('2023122917174618e1e630-2531-4','100020003300',0,'2023-12-29 00:00:00'),('202312291717461e14809c-493a-4','100020003300',0,'2023-12-29 00:00:00'),('202312291717461f14389a-a904-4','100020003300',0,'2023-12-29 00:00:00'),('20231229171746260f62f0-2caf-4','100020003300',0,'2023-12-29 00:00:00'),('202312291717462672a6d2-0f1f-4','100020003300',0,'2023-12-29 00:00:00'),('20231229171746379907a9-24c1-4','100020003300',0,'2023-12-29 00:00:00'),('20231229171746381bf0a6-1c1f-4','100020003300',0,'2023-12-29 00:00:00'),('20231229171746399c557c-c47b-4','100020003300',0,'2023-12-29 00:00:00'),('202312291717463db7c82c-67f5-4','100020003300',0,'2023-12-29 00:00:00'),('202312291717463e18048a-82f1-4','100020003300',0,'2023-12-29 00:00:00'),('2023122917174644aa8947-6513-4','100020003300',0,'2023-12-29 00:00:00'),('2023122917174648986e85-d19e-4','100020003300',0,'2023-12-29 00:00:00'),('2023122917174649153a58-7807-4','100020003300',0,'2023-12-29 00:00:00'),('202312291717464bb569cf-8275-4','100020003300',0,'2023-12-29 00:00:00'),('202312291717464ea511b0-98f5-4','100020003300',0,'2023-12-29 00:00:00'),('202312291717465658f3bb-e020-4','100020003300',0,'2023-12-29 00:00:00'),('2023122917174658645cde-5980-4','100020003300',0,'2023-12-29 00:00:00'),('202312291717465a4514ad-19f1-4','100020003300',0,'2023-12-29 00:00:00'),('202312291717465a45ecec-0f7b-4','100020003300',0,'2023-12-29 00:00:00'),('202312291717465be53f76-62f3-4','100020003300',0,'2023-12-29 00:00:00'),('202312291717466668a252-3fad-4','100020003300',0,'2023-12-29 00:00:00'),('2023122917174667b76526-9309-4','100020003300',0,'2023-12-29 00:00:00'),('202312291717466951ca79-97e2-4','100020003300',0,'2023-12-29 00:00:00'),('202312291717466bebc9d8-f1a5-4','100020003300',0,'2023-12-29 00:00:00'),('20231229171746708a4aa4-d01a-4','100020003300',0,'2023-12-29 00:00:00'),('2023122917174675d1aeea-11cb-4','100020003300',0,'2023-12-29 00:00:00'),('2023122917174676079611-af85-4','100020003300',0,'2023-12-29 00:00:00'),('202312291717467f6d9257-eb58-4','100020003300',0,'2023-12-29 00:00:00'),('2023122917174680c9508f-6c8d-4','100020003300',0,'2023-12-29 00:00:00'),('20231229171746814df036-a01a-4','100020003300',0,'2023-12-29 00:00:00'),('20231229171746825adbfe-4a11-4','100020003300',0,'2023-12-29 00:00:00'),('2023122917174682d25b47-eb6c-4','100020003300',0,'2023-12-29 00:00:00'),('2023122917174684586b60-ae65-4','100020003300',0,'2023-12-29 00:00:00'),('2023122917174687f938e0-cd98-4','100020003300',0,'2023-12-29 00:00:00'),('202312291717468f090ce9-58d4-4','100020003300',0,'2023-12-29 00:00:00'),('2023122917174690e7339d-3d08-4','100020003300',0,'2023-12-29 00:00:00'),('202312291717469765912c-054c-4','100020003300',0,'2023-12-29 00:00:00'),('20231229171746980d8f2d-736d-4','100020003300',0,'2023-12-29 00:00:00'),('20231229171746990d860c-5afb-4','100020003300',0,'2023-12-29 00:00:00'),('202312291717469c495a47-8475-4','100020003300',0,'2023-12-29 00:00:00'),('202312291717469ffdbac0-071a-4','100020003300',0,'2023-12-29 00:00:00'),('20231229171746a2eb4437-afcf-4','100020003300',0,'2023-12-29 00:00:00'),('20231229171746a7cd7ade-ad2f-4','100020003300',0,'2023-12-29 00:00:00'),('20231229171746a89e308b-6f52-4','100020003300',0,'2023-12-29 00:00:00'),('20231229171746a8d2cb61-dd4a-4','100020003300',0,'2023-12-29 00:00:00'),('20231229171746ae93c955-9c0e-4','100020003300',0,'2023-12-29 00:00:00'),('20231229171746b1d53d55-8368-4','100020003300',0,'2023-12-29 00:00:00'),('20231229171746b6b66496-2d5d-4','100020003300',0,'2023-12-29 00:00:00'),('20231229171746bf107929-3da7-4','100020003300',0,'2023-12-29 00:00:00'),('20231229171746c15001b1-aa55-4','100020003300',0,'2023-12-29 00:00:00'),('20231229171746c3e31cbe-50e4-4','100020003300',0,'2023-12-29 00:00:00'),('20231229171746c440bdc8-7b0c-4','100020003300',0,'2023-12-29 00:00:00'),('20231229171746c496c7b8-14f3-4','100020003300',0,'2023-12-29 00:00:00'),('20231229171746c7e75943-bd62-4','100020003300',0,'2023-12-29 00:00:00'),('20231229171746cf6d953e-7498-4','100020003300',0,'2023-12-29 00:00:00'),('20231229171746d059682e-603f-4','100020003300',0,'2023-12-29 00:00:00'),('20231229171746d0a59e5a-b607-4','100020003300',0,'2023-12-29 00:00:00'),('20231229171746d33a7910-9e82-4','100020003300',0,'2023-12-29 00:00:00'),('20231229171746d3a87ff2-8129-4','100020003300',0,'2023-12-29 00:00:00'),('20231229171746d90052a3-d088-4','100020003300',0,'2023-12-29 00:00:00'),('20231229171746e3eb5f9b-a00d-4','100020003300',0,'2023-12-29 00:00:00'),('20231229171746e5a119bb-9dcf-4','100020003300',0,'2023-12-29 00:00:00'),('20231229171746e6a15db6-3ab8-4','100020003300',0,'2023-12-29 00:00:00'),('20231229171746e8aad8b5-d461-4','100020003300',0,'2023-12-29 00:00:00'),('20231229171746e8fa5d74-2087-4','100020003300',0,'2023-12-29 00:00:00'),('20231229171746f22986b5-f1fa-4','100020003300',0,'2023-12-29 00:00:00'),('20231229171746f5dae03e-f9bd-4','100020003300',0,'2023-12-29 00:00:00'),('20231229171746f7c0a2fe-42dc-4','100020003300',0,'2023-12-29 00:00:00'),('20231229171746f85324ed-0af5-4','100020003300',0,'2023-12-29 00:00:00'),('20231229171746f9a5974f-1cdd-4','100020003300',0,'2023-12-29 00:00:00'),('20231229171746fa7e7b33-8627-4','100020003300',0,'2023-12-29 00:00:00'),('20231229171746fcdb9700-12d9-4','100020003300',0,'2023-12-29 00:00:00'),('20231229171746fd4f30d6-4c37-4','100020003300',0,'2023-12-29 00:00:00'),('20231229171746ff8a6cdf-59fd-4','100020003300',0,'2023-12-29 00:00:00');
/*!40000 ALTER TABLE `book_collect_info` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `book_type`
--

DROP TABLE IF EXISTS `book_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `book_type` (
  `BTID` int NOT NULL AUTO_INCREMENT,
  `BTName` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`BTID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `book_type`
--

LOCK TABLES `book_type` WRITE;
/*!40000 ALTER TABLE `book_type` DISABLE KEYS */;
INSERT INTO `book_type` VALUES (1,'文史类'),(2,'自然科学类'),(3,'工程技术类');
/*!40000 ALTER TABLE `book_type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `borrow_record`
--

DROP TABLE IF EXISTS `borrow_record`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `borrow_record` (
  `borrow_ID` varchar(30) NOT NULL,
  `ReaderID` varchar(30) DEFAULT NULL,
  `AID` varchar(10) DEFAULT NULL,
  `BCID` varchar(30) DEFAULT NULL,
  `borrow_date` datetime DEFAULT NULL,
  `due_date` datetime DEFAULT NULL,
  `renewal_count` int DEFAULT NULL,
  `is_return` int DEFAULT '0',
  PRIMARY KEY (`borrow_ID`),
  KEY `FK_Reference_3` (`ReaderID`),
  KEY `FK_Reference_4` (`AID`),
  KEY `FK_Reference_5` (`BCID`),
  CONSTRAINT `FK_Reference_3` FOREIGN KEY (`ReaderID`) REFERENCES `reader_info` (`ReaderID`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Reference_4` FOREIGN KEY (`AID`) REFERENCES `admin_info` (`AID`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Reference_5` FOREIGN KEY (`BCID`) REFERENCES `book_collect_info` (`BCID`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `borrow_record`
--

LOCK TABLES `borrow_record` WRITE;
/*!40000 ALTER TABLE `borrow_record` DISABLE KEYS */;
INSERT INTO `borrow_record` VALUES ('20231222175854e190dcf5-f59b-4','20210902150601','12172231','2023121716132022d8cbae-f3d1-4','2023-12-22 17:58:54','2024-03-21 17:58:54',0,1),('20231225125251e64c960d-a3a3-4','20210902150601','12172231','2023121716132030333f7b-e4ba-4','2023-12-25 12:52:51','2024-03-24 12:52:51',0,1),('20231225152110a96ed8d6-2e01-4','20210902150601','12172231','202312171616110054e2a3-e423-4','2023-12-25 15:21:11','2024-03-24 15:21:11',0,0),('202312282308542c116a6a-a4cb-4','20210902150601','12172231','202312171616110a51853a-0b8f-4','2023-12-28 23:08:55','2024-03-27 23:08:55',0,1),('20231228230929ebabd248-7b9f-4','202312282255322b87b762-c7e3-4','12172231','202312171616110acc004b-9208-4','2023-12-28 23:09:29','2024-03-27 23:09:29',0,0),('202312282310294e3e6c52-4c08-4','202312282255322b87b762-c7e3-4','12172231','202312171613203105a2a6-b40a-4','2023-12-28 23:10:29','2024-03-27 23:10:29',0,0),('20231229170408c0c2e4dd-3eda-4','20210902150601','12172231','20231229170301007ba1c6-031a-4','2023-12-29 17:04:08','2024-03-28 17:04:08',0,1),('20231229171027d55d1d9b-dfc1-4','20231229170631531d4217-696a-4','12172231','20231229170301032abf3e-a805-4','2023-12-29 17:10:28','2024-03-28 17:10:28',0,0),('20231229172144e487ce9c-190d-4','202312291720082fedb5bd-31f6-4','12172231','2023121716132032110dbb-e7f2-4','2023-12-29 17:21:45','2024-03-28 17:21:45',0,0),('20231229173556968349d8-6059-4','20231229173306a1332304-b918-4','12172231','20231229171745ca5059af-054a-4','2023-12-29 17:35:56','2024-03-28 17:35:56',0,0),('202401251603422f9bbf1b-1943-4','20210902150601','12172231','20231229170301051c2860-7296-4','2024-01-25 16:03:42','2024-04-24 16:03:42',0,1),('202401251616580a4d3815-4875-4','20210902150601','12172231','2023122917174600a266af-a90f-4','2024-01-25 16:16:59','2024-04-24 16:16:59',0,1),('202401252014299b6f71d5-bf98-4','20210902150601','12172231','2023121716132007ccda00-f434-4','2024-01-25 20:14:30','2024-04-24 20:14:30',0,1),('202401252015279ad2c821-9bf9-4','20210902150601','12172231','202312171613201dda5161-5241-4','2024-01-25 20:15:27','2024-04-24 20:15:27',0,0);
/*!40000 ALTER TABLE `borrow_record` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = gbk */ ;
/*!50003 SET character_set_results = gbk */ ;
/*!50003 SET collation_connection  = gbk_chinese_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `tri_insert_borrowRecord` AFTER INSERT ON `borrow_record` FOR EACH ROW Insert into log_info VALUES(null,concat("���ļ�¼���",new.Borrow_id,"������һ�����ļ�¼,�û� ",new.readerid," ������һ�� ",new.BCID)) */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `log_info`
--

DROP TABLE IF EXISTS `log_info`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `log_info` (
  `log_id` int NOT NULL AUTO_INCREMENT,
  `log_text` text,
  PRIMARY KEY (`log_id`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `log_info`
--

LOCK TABLES `log_info` WRITE;
/*!40000 ALTER TABLE `log_info` DISABLE KEYS */;
INSERT INTO `log_info` VALUES (1,'借阅记录编号202020生成了一条借阅记录,用户 ReaderID 借阅了一本 BCID'),(2,'借阅记录编号20231222174251d2b72ddc-427f-4生成了一条借阅记录,用户 20210902150601 借阅了一本 2023121716132007ccda00-f434-4'),(3,'借阅记录编号202312221745235dfbbadc-74df-4生成了一条借阅记录,用户 20210902150601 借阅了一本 202312171613201dda5161-5241-4'),(4,'借阅记录编号20231222175854e190dcf5-f59b-4生成了一条借阅记录,用户 20210902150601 借阅了一本 2023121716132022d8cbae-f3d1-4'),(6,'借阅记录编号20231225125251e64c960d-a3a3-4生成了一条借阅记录,用户 20210902150601 借阅了一本 2023121716132030333f7b-e4ba-4'),(7,'借阅记录编号20231225152110a96ed8d6-2e01-4生成了一条借阅记录,用户 20210902150601 借阅了一本 202312171616110054e2a3-e423-4'),(8,'借阅记录编号202312282308542c116a6a-a4cb-4生成了一条借阅记录,用户 20210902150601 借阅了一本 202312171616110a51853a-0b8f-4'),(9,'借阅记录编号20231228230929ebabd248-7b9f-4生成了一条借阅记录,用户 202312282255322b87b762-c7e3-4 借阅了一本 202312171616110acc004b-9208-4'),(10,'借阅记录编号202312282310294e3e6c52-4c08-4生成了一条借阅记录,用户 202312282255322b87b762-c7e3-4 借阅了一本 202312171613203105a2a6-b40a-4'),(11,'借阅记录编号20231229170408c0c2e4dd-3eda-4生成了一条借阅记录,用户 20210902150601 借阅了一本 20231229170301007ba1c6-031a-4'),(12,'借阅记录编号20231229171027d55d1d9b-dfc1-4生成了一条借阅记录,用户 20231229170631531d4217-696a-4 借阅了一本 20231229170301032abf3e-a805-4'),(13,'借阅记录编号20231229172144e487ce9c-190d-4生成了一条借阅记录,用户 202312291720082fedb5bd-31f6-4 借阅了一本 2023121716132032110dbb-e7f2-4'),(14,'借阅记录编号20231229173556968349d8-6059-4生成了一条借阅记录,用户 20231229173306a1332304-b918-4 借阅了一本 20231229171745ca5059af-054a-4'),(15,'借阅记录编号202401251603422f9bbf1b-1943-4生成了一条借阅记录,用户 20210902150601 借阅了一本 20231229170301051c2860-7296-4'),(16,'借阅记录编号202401251616580a4d3815-4875-4生成了一条借阅记录,用户 20210902150601 借阅了一本 2023122917174600a266af-a90f-4'),(17,'借阅记录编号202401252014299b6f71d5-bf98-4生成了一条借阅记录,用户 20210902150601 借阅了一本 2023121716132007ccda00-f434-4'),(18,'借阅记录编号202401252015279ad2c821-9bf9-4生成了一条借阅记录,用户 20210902150601 借阅了一本 202312171613201dda5161-5241-4');
/*!40000 ALTER TABLE `log_info` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `manager`
--

DROP TABLE IF EXISTS `manager`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `manager` (
  `name` varchar(20) DEFAULT NULL,
  `password` varchar(40) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `manager`
--

LOCK TABLES `manager` WRITE;
/*!40000 ALTER TABLE `manager` DISABLE KEYS */;
INSERT INTO `manager` VALUES ('大陈','666');
/*!40000 ALTER TABLE `manager` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `publish_house_info`
--

DROP TABLE IF EXISTS `publish_house_info`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `publish_house_info` (
  `publish_HID` varchar(10) NOT NULL,
  `PDName` varchar(20) DEFAULT NULL,
  `contact_name` varchar(10) DEFAULT NULL,
  `contact` varchar(20) DEFAULT NULL,
  `fax` varchar(20) DEFAULT NULL,
  `address` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`publish_HID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `publish_house_info`
--

LOCK TABLES `publish_house_info` WRITE;
/*!40000 ALTER TABLE `publish_house_info` DISABLE KEYS */;
INSERT INTO `publish_house_info` VALUES ('100','机械工业出版社','梁生','111222333','无','教育路东168号');
/*!40000 ALTER TABLE `publish_house_info` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reader_info`
--

DROP TABLE IF EXISTS `reader_info`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `reader_info` (
  `ReaderID` varchar(30) NOT NULL,
  `RTypeID` int DEFAULT NULL,
  `Rname` varchar(10) DEFAULT NULL,
  `sex` int DEFAULT NULL,
  `regist_date` date DEFAULT NULL,
  `valid_to` date DEFAULT NULL,
  `Contact` varchar(20) DEFAULT NULL,
  `hold_count` int DEFAULT NULL,
  `borrow_count` int DEFAULT NULL,
  `break_time` int DEFAULT NULL,
  `state` int DEFAULT NULL,
  `Remark` text,
  `password` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ReaderID`),
  KEY `FK_Reference_2` (`RTypeID`),
  CONSTRAINT `FK_Reference_2` FOREIGN KEY (`RTypeID`) REFERENCES `readertype` (`RTypeID`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reader_info`
--

LOCK TABLES `reader_info` WRITE;
/*!40000 ALTER TABLE `reader_info` DISABLE KEYS */;
INSERT INTO `reader_info` VALUES ('20210902150601',1,'jack',0,'2021-09-01','2025-09-01','12345678999',2,9,0,0,'fine ，wuhu','123456'),('202312282255322b87b762-c7e3-4',2,'帅气一哥们',0,'2023-12-28','2025-10-10','101010101010',2,2,0,0,'很好','8888'),('20231229170631531d4217-696a-4',1,'华作',0,'2023-12-29','2025-01-01','98765432188',1,1,0,0,'好得很','321going'),('202312291720082fedb5bd-31f6-4',2,'王老师',1,'2023-12-29','2026-10-09','8908080',1,1,0,0,'remarking','567'),('20231229173306a1332304-b918-4',1,'阿百',0,'2023-12-29','2026-10-10','1234567999',1,1,0,0,'好','7890');
/*!40000 ALTER TABLE `reader_info` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `readertype`
--

DROP TABLE IF EXISTS `readertype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `readertype` (
  `RTypeID` int NOT NULL AUTO_INCREMENT,
  `RType` varchar(20) DEFAULT NULL,
  `count_limit` int DEFAULT NULL,
  `day_limit` int DEFAULT NULL,
  PRIMARY KEY (`RTypeID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `readertype`
--

LOCK TABLES `readertype` WRITE;
/*!40000 ALTER TABLE `readertype` DISABLE KEYS */;
INSERT INTO `readertype` VALUES (1,'学生',5,100),(2,'教师',10,150);
/*!40000 ALTER TABLE `readertype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `return_record`
--

DROP TABLE IF EXISTS `return_record`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `return_record` (
  `return_ID` varchar(40) NOT NULL,
  `ReaderID` varchar(30) DEFAULT NULL,
  `BCID` varchar(30) DEFAULT NULL,
  `AID` varchar(30) DEFAULT NULL,
  `borrow_ID` varchar(30) DEFAULT NULL,
  `return_time` datetime DEFAULT NULL,
  `time_limit_exceed` int DEFAULT NULL,
  `damage` int DEFAULT NULL,
  PRIMARY KEY (`return_ID`),
  KEY `FK_Reference_13` (`ReaderID`),
  KEY `FK_Reference_14` (`BCID`),
  KEY `FK_Reference_15` (`AID`),
  KEY `FK_Reference_16` (`borrow_ID`),
  CONSTRAINT `FK_Reference_13` FOREIGN KEY (`ReaderID`) REFERENCES `reader_info` (`ReaderID`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Reference_14` FOREIGN KEY (`BCID`) REFERENCES `book_collect_info` (`BCID`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Reference_15` FOREIGN KEY (`AID`) REFERENCES `admin_info` (`AID`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Reference_16` FOREIGN KEY (`borrow_ID`) REFERENCES `borrow_record` (`borrow_ID`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `return_record`
--

LOCK TABLES `return_record` WRITE;
/*!40000 ALTER TABLE `return_record` DISABLE KEYS */;
INSERT INTO `return_record` VALUES ('202401251559525017bd15-0c25-4','20210902150601','2023121716132022d8cbae-f3d1-4','12130913','20231222175854e190dcf5-f59b-4','2024-01-25 15:59:53',0,0),('2024012516162068bb8f71-a395-4','20210902150601','2023121716132030333f7b-e4ba-4','12130913','20231225125251e64c960d-a3a3-4','2024-01-25 16:16:20',0,0),('2024012516321749e135c1-c40d-4','20210902150601','202312171616110a51853a-0b8f-4','12130913','202312282308542c116a6a-a4cb-4','2024-01-25 16:32:17',0,0),('2024012516344633ba253e-dc55-4','20210902150601','2023122917174600a266af-a90f-4','12130913','202401251616580a4d3815-4875-4','2024-01-25 16:34:47',0,1),('20240125165215cf6ba51d-b298-4','20210902150601','20231229170301051c2860-7296-4','12130913','202401251603422f9bbf1b-1943-4','2024-01-25 16:52:15',0,0),('2024012516540135f1277f-c5c5-4','20210902150601','20231229170301007ba1c6-031a-4','12130913','20231229170408c0c2e4dd-3eda-4','2024-01-25 16:54:02',0,1),('20240125201634a0e77eb0-7693-4','20210902150601','2023121716132007ccda00-f434-4','12130913','202401252014299b6f71d5-bf98-4','2024-01-25 20:16:35',0,0);
/*!40000 ALTER TABLE `return_record` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `name` varchar(20) DEFAULT NULL,
  `password` varchar(40) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES ('jack','123456');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

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

-- Dump completed on 2024-01-25 21:13:09
