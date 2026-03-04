# Image Upload and Optimization Features

## Overview
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