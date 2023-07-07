import cv2
import pathlib

cascade_path= pathlib.Path(cv2.__file__).parent.absolute() / "data/haarcascade_frontalface_default.xml"
face_classifier=cv2.CascadeClassifier(str(cascade_path))
capture=cv2.VideoCapture(0)
img=cv2.imread("E:/face_recognization/1000_F_227954844_Sg0x6kNNtBRgDwlkV04x44hsp0YHga1z.jpg")
while 1:
    ret, frame=capture.read()
    gray=cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)
    faces=face_classifier.detectMultiScale(gray, 1.3, 5)
    for (x,y,w,z) in faces:
            overlay_image = cv2.resize(img, (w, z))
            cv2.rectangle(frame, (x, y), (x+w, y+z), (255, 255, 0), 2)
            frame[y:y + z, x:x + w] = overlay_image



    cv2.imshow('Video', frame)
    if cv2.waitKey(30) & 0xFF == ord('q'):
        break

capture.release()
cv2.destroyAllWindows()