# Stagedoor - Theatre/Performance Attendance System
# Attendance System Project

A comprehensive ASP.NET Core Web API for managing theatre performances and attendance tracking using NFC technology.
## Overview
The Attendance System is designed to streamline the process of recording and managing attendance in a variety of settings, such as schools, universities, and workplaces. This system aims to enhance accuracy and efficiency in attendance tracking while providing an intuitive user interface for both administrators and users.

## Features
- Organization Management: Create and manage organisations/theatre groups
- Show Management: Organize shows with multiple performances
- Performance Management: Schedule and track individual performances
- Member Management: Register members with NFC tag support
- Attendance Tracking: Automated check-in/check-out with NFC readers
- Reporting: View attendance logs and statistics

## Architecture
### Models
- Organisation: Theatre groups or companies
- Show: Production shows
- Performance: Individual show performances
- Member: Performers with NFC tags
- AttendanceLog: Check-in/check-out records

### Services
- OrganisationService: Organisation CRUD operations
- ShowService: Show management
- PerformanceService: Performance scheduling and tracking
- MemberService: Member management with NFC support
- AttendanceService: Check-in/check-out operations
- NFCReaderService: NFC hardware communication

### Controllers
- OrganisationController: REST endpoints for organisations
- ShowController: REST endpoints for shows
- PerformanceController: REST endpoints for performances
- MemberController: REST endpoints for members
- AttendanceController: REST endpoints for attendance

## API Endpoints
### Organisations
- GET /api/organisation - Get all organisations
- GET /api/organisation/{id} - Get organisation details
- POST /api/organisation - Create organisation
- PUT /api/organisation/{id} - Update organisation
- DELETE /api/organisation/{id} - Delete organisation

### Shows
- GET /api/show/{id} - Get show details
- GET /api/show/organisation/{organisationId} - Get shows by organisation
- POST /api/show - Create show
- PUT /api/show/{id} - Update show
- DELETE /api/show/{id} - Delete show

### Performances
- GET /api/performance/{id} - Get performance details
- GET /api/performance/show/{showId} - Get performances by show
- GET /api/performance/{id}/attendance - Get performance attendance
- POST /api/performance - Create performance
- PUT /api/performance/{id} - Update performance
- DELETE /api/performance/{id} - Delete performance

### Members
- GET /api/member/by-nfc/{nfcTagId} - Get member by NFC tag
- GET /api/member/organisation/{organisationId} - Get members by organisation
- POST /api/member - Create member
- PUT /api/member/{id} - Update member
- DELETE /api/member/{id} - Delete member

### Attendance
- POST /api/attendance/check-in/{performanceId} - Check in with NFC
- POST /api/attendance/check-out/{memberId}/{performanceId} - Check out
- GET /api/attendance/{memberId}/{performanceId} - Get attendance log
- **User Authentication**: Secure login and registration for users.
- **Attendance Tracking**: Easy recording of attendance with options for marking present, absent, or late.
- **Reporting**: Generation of detailed attendance reports and analytics.
- **Notifications**: Automated reminders for users regarding attendance policies and deadlines.
- **User Management**: Admin interface for managing user accounts and roles.

## Installation Instructions
1. **Clone the Repository**:
   ```bash
   git clone https://github.com/lawrelu/TheLawrenceHousePsychologicalServices.git
   ```
2. **Navigate to Project Directory**:
   ```bash
   cd TheLawrenceHousePsychologicalServices
   ```
3. **Install Dependencies**:
   ```bash
   npm install  # or yarn install
   ```

## Usage Instructions
1. Start the application:
   ```bash
   npm start  # or yarn start
   ```
2. Access the application at `http://localhost:3000`.

## Contributing
We welcome contributions from the community! If you would like to contribute, please follow these steps:
1. Fork the repository.
2. Create a new branch for your feature or bug fix.
3. Make your changes and commit them with clear messages.
4. Push your changes and create a pull request.

## License
This project is licensed under the MIT License.

## Contact
For any inquiries, please reach out to [lawrelu@gmail.com](mailto:lawrelu@gmail.com).# Image Upload and Optimization Features

## Image Optimisaation
This section covers the image upload and optimization features available for organization logos and show posters in the application. 

## Endpoints
### Upload Logo
- **Endpoint**: `/api/uploads/logo`
- **Method**: `POST`
- **Request Body**:
  - `file`: The image file to upload (must be of type PNG, JPG, or JPEG)

### Upload Show Poster
- **Endpoint**: `/api/uploads/poster`
- **Method**: `POST`
- **Request Body**:
  - `file`: The image file to upload (must be of type PNG, JPG, or JPEG)

## Specifications
- **Image Size Limit**: Each uploaded image must not exceed 5 MB.
- **Image Dimensions**: Logos should ideally be 300x300 pixels; show posters should be 1080x1920 pixels.

## Uploading Images
1. Make a `POST` request to the desired endpoint.
2. Ensure that the image file is included in the request.
3. The server will process the image and return a response indicating success or failure.

## Usage Examples
### Example for Uploading a Logo
```bash
curl -X POST http://localhost:3000/api/uploads/logo \ 
-F "file=@path/to/logo.png" 
```

### Example for Uploading a Show Poster
```bash
curl -X POST http://localhost:3000/api/uploads/poster \ 
-F "file=@path/to/poster.jpg" 
```

## Image Optimization
Once uploaded, images are optimized to reduce file size while maintaining quality. This includes compression techniques suitable for web application performance.
