# Use an offical python runtime as a parent image
FROM python:3

# Set the working directory to /app
WORKDIR /app

# Copy the current directory contents into th container at /app
COPY . /app

# Install any needed packages specified in the requirements.yxy
RUN pip install --trusted-host pypi.python.org -r requirements.txt 

# Make port 80 available to the world outside this container
EXPOSE 80

# Define an environment variable
ENV NAME world

# Run app.py when the container launches
CMD ["python", "app.py"]