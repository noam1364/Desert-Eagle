import tensorflow as tf
import keras
from keras.models import Sequential
from keras.optimizers import Adam
from keras.layers import Dense, Conv2D, Dropout, Flatten, MaxPooling2D

#CNN Model
model = Sequential()
model.add(Dense(2, activation='relu',use_bias=True,input_shape = (2,)))
model.add(Dense(6,activation = 'relu',use_bias = True))
model.add(Dense(1,activation=tf.nn.sigmoid))

i = input('Initiate new model?y/n\n')
if i =='y':
	model.save('C:\Workspaces\C# workspace\Project Hindenburg\Project Hindenburg\geneticModel\Model.h5')
	input('Model Saved')