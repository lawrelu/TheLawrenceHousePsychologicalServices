# Stagedoor - Theatre/Performance Attendance System

A comprehensive ASP.NET Core Web API for managing theatre performances and attendance tracking using NFC technology.

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