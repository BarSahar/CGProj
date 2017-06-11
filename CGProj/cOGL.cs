using System;
using System.Collections.Generic;
using System.Windows.Forms;
//using NAudio;

//2
using System.Drawing;

namespace OpenGL
{
    class cOGL
    {
        Control p;
        int Width;
        int Height;

        GLUquadric obj;

        public cOGL(Control pb)
        {
            p = pb;
            Width = p.Width;
            Height = p.Height;
            /////TODO: delete this
            //GL.glVertex3d(0, 0, 5);
            //GL.glVertex3d(0, 10, 5);
            //GL.glVertex3d(10, 10, 5);
            /////
            ground[0, 0] = 10f;
            ground[0, 1] = 10f;
            ground[0, 2] = 5.1f;

            ground[1, 0] = 0f;
            ground[1, 1] = 10f;
            ground[1, 2] = 5.1f;

            ground[2, 0] = 0f;
            ground[2, 1] = 0f;
            ground[2, 2] = 5.1f;
            

            InitializeGL();
            obj = GLU.gluNewQuadric(); //!!!

            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = "song.wav";
            player.PlayLooping();
            
        }

        ~cOGL()
        {
            GLU.gluDeleteQuadric(obj); //!!!
            WGL.wglDeleteContext(m_uint_RC);
        }

        uint m_uint_HWND = 0;

        public uint HWND
        {
            get { return m_uint_HWND; }
        }

        uint m_uint_DC = 0;

        public uint DC
        {
            get { return m_uint_DC; }
        }
        uint m_uint_RC = 0;

        public uint RC
        {
            get { return m_uint_RC; }
        }


        
        void DrawHoleInAPit()
        {
            GL.glBegin(GL.GL_QUADS);
            GL.glTexCoord2f(0.0f, 0.0f);
            GL.glVertex3d(-5, 0, 5);
            GL.glTexCoord2f(0.0f, 1.0f);
            GL.glVertex3d(-5, 10, 5);
            GL.glTexCoord2f(1.0f, 1.0f);
            GL.glVertex3d(5, 10, 5);
            GL.glTexCoord2f(1.0f, 0.0f);
            GL.glVertex3d(5, 0, 5);
            GL.glEnd();
        }

        void DrawChest()
        {
            GL.glPushMatrix();// save starting position of drawing
            GL.glTranslatef(-5.0f, 0.0f, 0.0f);
            GL.glColor3f(1.0f, 1.0f, 1.0f);
            GL.glEnable(GL.GL_TEXTURE_2D);
            GL.glBindTexture(GL.GL_TEXTURE_2D, Textures[0]);
            GL.glBegin(GL.GL_QUADS);
            
            //bottom
            GL.glTexCoord2f(0.0f, 0.0f);
            GL.glVertex3d(0, 0, 0);
            GL.glTexCoord2f(0.0f, 1.0f);
            GL.glVertex3d(0, 10, 0);
            GL.glTexCoord2f(1.0f, 1.0f);
            GL.glVertex3d(10, 10, 0);
            GL.glTexCoord2f(1.0f, 0.0f);
            GL.glVertex3d(10, 0, 0);
            
            //top
            GL.glTexCoord2f(0.0f, 0.0f);
            GL.glVertex3d(0, 0, 5);
            GL.glTexCoord2f(0.0f, 1.0f);
            GL.glVertex3d(0, 10, 5);
            GL.glTexCoord2f(1.0f, 1.0f);
            GL.glVertex3d(10, 10, 5);
            GL.glTexCoord2f(1.0f, 0.0f);
            GL.glVertex3d(10, 0, 5);

            GL.glEnd();
            GL.glBindTexture(GL.GL_TEXTURE_2D, Textures[1]);
            GL.glBegin(GL.GL_QUADS);

            //top - other texture
            GL.glTexCoord2f(0.0f, 0.0f);
            GL.glVertex3d(0.5, 0.5, 5.01f);
            GL.glTexCoord2f(0.0f, 1.0f);
            GL.glVertex3d(0.5, 9.5, 5.01f);
            GL.glTexCoord2f(1.0f, 1.0f);
            GL.glVertex3d(9.5, 9.5, 5.01f);
            GL.glTexCoord2f(1.0f, 0.0f);
            GL.glVertex3d(9.5, 0.5, 5.01f);

            GL.glEnd();
            GL.glBindTexture(GL.GL_TEXTURE_2D, Textures[0]);
            GL.glBegin(GL.GL_QUADS);

            //front
            GL.glTexCoord2f(0.0f, 0.0f);
            GL.glVertex3d(0, 10, 0);
            GL.glTexCoord2f(0.0f, 1.0f);
            GL.glVertex3d(0, 10, 5);
            GL.glTexCoord2f(1.0f, 1.0f);
            GL.glVertex3d(10, 10, 5);
            GL.glTexCoord2f(1.0f, 0.0f);
            GL.glVertex3d(10, 10, 0);

            //back
            GL.glTexCoord2f(0.0f, 0.0f);
            GL.glVertex3d(0, 0, 0);
            GL.glTexCoord2f(0.0f, 1.0f);
            GL.glVertex3d(0, 0, 5);
            GL.glTexCoord2f(1.0f, 1.0f);
            GL.glVertex3d(10, 0, 5);
            GL.glTexCoord2f(1.0f, 0.0f);
            GL.glVertex3d(10, 0, 0);

            //left
            GL.glTexCoord2f(0.0f, 0.0f);
            GL.glVertex3d(0, 0, 0);
            GL.glTexCoord2f(0.0f, 1.0f);
            GL.glVertex3d(0, 0, 5);
            GL.glTexCoord2f(1.0f, 1.0f);
            GL.glVertex3d(0, 10, 5);
            GL.glTexCoord2f(1.0f, 0.0f);
            GL.glVertex3d(0, 10, 0);

            //right
            GL.glTexCoord2f(0.0f, 0.0f);
            GL.glVertex3d(10, 0, 0);
            GL.glTexCoord2f(0.0f, 1.0f);
            GL.glVertex3d(10, 0, 5);
            GL.glTexCoord2f(1.0f, 1.0f);
            GL.glVertex3d(10, 10, 5);
            GL.glTexCoord2f(1.0f, 0.0f);
            GL.glVertex3d(10, 10, 0);

            GL.glEnd();
            GL.glDisable(GL.GL_TEXTURE_2D);
            GL.glPopMatrix();
        }
        void DrawChestLid()
        {
            GL.glPushMatrix();// save starting position of drawing

            GL.glColor3f(1.0f, 1.0f, 1.0f);
            GL.glEnable(GL.GL_TEXTURE_2D);
            GL.glBindTexture(GL.GL_TEXTURE_2D, Textures[0]);
            GL.glTranslatef(-5.0f, 0.0f, 0.0f);
            GL.glTranslatef(0, 10.0f, 5.0f);
            GL.glRotated(mirrorAngle, 1, 0, 0);

            GL.glBegin(GL.GL_QUADS);

            //bottom
            GL.glTexCoord2f(0.0f, 0.0f);
            GL.glVertex3d(0, 0, -2);
            GL.glTexCoord2f(0.0f, 1.0f);
            GL.glVertex3d(0, 10, -2);
            GL.glTexCoord2f(1.0f, 1.0f);
            GL.glVertex3d(10, 10, -2);
            GL.glTexCoord2f(1.0f, 0.0f);
            GL.glVertex3d(10, 0, -2);

            //top
            GL.glTexCoord2f(0.0f, 0.0f);
            GL.glVertex3d(0, 0, 0);
            GL.glTexCoord2f(0.0f, 1.0f);
            GL.glVertex3d(0, 10, 0);
            GL.glTexCoord2f(1.0f, 1.0f);
            GL.glVertex3d(10, 10, 0);
            GL.glTexCoord2f(1.0f, 0.0f);
            GL.glVertex3d(10, 0, 0);

            //front
            GL.glTexCoord2f(0.0f, 0.0f);
            GL.glVertex3d(0, 10, -2);
            GL.glTexCoord2f(0.0f, 1.0f);
            GL.glVertex3d(0, 10, 0);
            GL.glTexCoord2f(1.0f, 1.0f);
            GL.glVertex3d(10, 10, 0);
            GL.glTexCoord2f(1.0f, 0.0f);
            GL.glVertex3d(10, 10, -2);

            //back
            GL.glTexCoord2f(0.0f, 0.0f);
            GL.glVertex3d(0, 0, -2);
            GL.glTexCoord2f(0.0f, 1.0f);
            GL.glVertex3d(0, 0, 0);
            GL.glTexCoord2f(1.0f, 1.0f);
            GL.glVertex3d(10, 0, 0);
            GL.glTexCoord2f(1.0f, 0.0f);
            GL.glVertex3d(10, 0, -2);

            //left
            GL.glTexCoord2f(0.0f, 0.0f);
            GL.glVertex3d(0, 0, -2);
            GL.glTexCoord2f(0.0f, 1.0f);
            GL.glVertex3d(0, 0, 0);
            GL.glTexCoord2f(1.0f, 1.0f);
            GL.glVertex3d(0, 10, 0);
            GL.glTexCoord2f(1.0f, 0.0f);
            GL.glVertex3d(0, 10, -2);

            //right
            GL.glTexCoord2f(0.0f, 0.0f);
            GL.glVertex3d(10, 0, -2);
            GL.glTexCoord2f(0.0f, 1.0f);
            GL.glVertex3d(10, 0, 0);
            GL.glTexCoord2f(1.0f, 1.0f);
            GL.glVertex3d(10, 10, 0);
            GL.glTexCoord2f(1.0f, 0.0f);
            GL.glVertex3d(10, 10, -2);

            GL.glEnd();
            GL.glDisable(GL.GL_TEXTURE_2D);
            GL.glPopMatrix();
        }
        void DrawTheWomanInRed(bool shadow)
        {
            GL.glPushMatrix();// save starting position of drawing
            if (shadow ==true)
                GL.glColor3f(0.0f, 0.0f, 0.0f);
            else
                GL.glColor3f(1.0f, 1.0f, 1.0f);

            //GL.glTranslatef(-5.0f, -5.0f, 5.2f);
            GL.glTranslatef(0f, 5f, 5.2f);
            GL.glRotated(intOptionC, 0, 0, 1); //rotating the dancer
            GL.glPushMatrix();// save position of dancer
            //left shoe
            if (shadow == false)
                pre_MapSphereTexture(2);
            GL.glRotated(90, 1, 0, 0);
            GLUT.glutSolidTeapot(0.5);
            GL.glRotated(-90, 1, 0, 0);
            end_MapTexture();
            //left leg
            if (shadow == false)
                pre_MapCylinderTexture(3);
            GLU.gluCylinder(obj, 0.2, 0.4, 4, 20, 20);
            GL.glTranslated(0.4f, 0f, 2f);
            end_MapTexture();
            //right leg
            GL.glRotated(50, 0, 1, 0);
            //right shoe
            if (shadow == false)
                pre_MapSphereTexture(2);
            GL.glRotated(90, 1, 0, 0);
            GLUT.glutSolidTeapot(0.5);
            GL.glRotated(-90, 1, 0, 0);
            end_MapTexture();
            //lower right leg
            if (shadow == false)
                pre_MapCylinderTexture(3);
            GLU.gluCylinder(obj, 0.2, 0.25, 2, 20, 20);
            GL.glTranslated(0f, 0f, 2f);
            GL.glRotated(-100, 0, 1, 0);
            //right knee
            GLU.gluSphere(obj, 0.25, 20, 20);
            //upper second leg
            GLU.gluCylinder(obj, 0.25, 0.4, 2, 20, 20);
            GL.glPopMatrix(); //reset position to the first leg
            end_MapTexture();
            //skirt
            if (shadow == false)
                pre_MapCylinderTexture(4);
            GL.glTranslated(0f, 0f, 4f);
            GLU.gluCylinder(obj, 2, 0.75, 1.5, 20, 20); 
            GL.glTranslated(0f, 0f, 1.5f);
            end_MapTexture();
            if (shadow == false)
                pre_MapCylinderTexture(5);
            GLU.gluCylinder(obj, 0.75, 0.75, 2.5, 20, 20); 
            GL.glTranslated(0f, 0f, 2.5f);
            end_MapTexture();
            //upper blob
            if (shadow == false)
                pre_MapSphereTexture(5);
            GLU.gluSphere(obj, 0.75, 20, 20);
            end_MapTexture();
            //Right
            GL.glPushMatrix();
            GL.glTranslated(0.75f, 0f, 0f);
            //right shoulder
            if (shadow == false)
                pre_MapSphereTexture(5);
            GLU.gluSphere(obj, 0.3, 20, 20);
            end_MapTexture();
            GL.glRotated(shoulderAngle, 1, 0, 0);
            //right arm
            if (shadow == false)
                pre_MapCylinderTexture(5);
            GLU.gluCylinder(obj, 0.2, 0.19, 1.5, 20, 20);
            GL.glTranslated(0.0f, 0f, 1.5f);
            end_MapTexture();
            //right elbow
            if (shadow == false)
                pre_MapSphereTexture(5);
            GLU.gluSphere(obj, 0.3, 20, 20);
            GL.glRotated(-15, 1, 0, 0);
            end_MapTexture();
            //right forearm
            if (shadow == false)
                pre_MapCylinderTexture(3);
            GLU.gluCylinder(obj, 0.2, 0.19, 1.5, 20, 20);
            GL.glTranslated(0.0f, 0f, 1.5f);
            //right hand
            GLU.gluCylinder(obj, 0.2, 0, .5, 20, 20);
            GL.glPopMatrix();
            end_MapTexture();
            //Left
            GL.glPushMatrix();
            GL.glTranslated(-0.75f, 0f, 0f);
            //left shoulder
            if (shadow == false)
                pre_MapSphereTexture(5);
            GLU.gluSphere(obj, 0.3, 20, 20); 
            GL.glRotated(shoulderAngle, 1, 0, 0);
            end_MapTexture();
            //left arm
            if (shadow == false)
                pre_MapCylinderTexture(5);
            GLU.gluCylinder(obj, 0.2, 0.19, 1.5, 20, 20); 
            GL.glTranslated(0.0f, 0f, 1.5f);
            end_MapTexture();
            //left elbow
            if (shadow == false)
                pre_MapSphereTexture(5);
            GLU.gluSphere(obj, 0.3, 20, 20); 
            GL.glRotated(-15, 1, 0, 0);
            end_MapTexture();
            //left forearm
            if (shadow == false)
                pre_MapCylinderTexture(3);
            GLU.gluCylinder(obj, 0.2, 0.19, 1.5, 20, 20); 
            GL.glTranslated(0.0f, 0f, 1.5f);
            //left hand
            GLU.gluCylinder(obj, 0.2, 0, .5, 20, 20); 
            GL.glPopMatrix();
            //neck
            GLU.gluCylinder(obj, 0.2, 0.19, 0.5+0.75, 20, 20); 
            GL.glTranslated(0.0f, 0f, 1.2f);
            end_MapTexture();
            //head
            if (shadow == false)
                pre_MapCylinderTexture(6);
            GLU.gluSphere(obj, 0.5, 20, 20); 
            GL.glPopMatrix();
            end_MapTexture();
        }
        void DrawMirror()
        {
            GL.glPushMatrix();
            GL.glTranslated(-5, 10, 5);
            GL.glRotated(mirrorAngle, 1, 0, 0);
            GL.glEnable(GL.GL_LIGHTING);
            GL.glBegin(GL.GL_QUADS);
            /*GL.glColor3d(1, 1, 1);
            GL.glVertex3d(0.5, 0.5, 0.1f);
            GL.glVertex3d(0.5, 9.5, 0.1f);
            GL.glVertex3d(9.5, 9.5, 0.1f);
            GL.glVertex3d(9.5, 0.5, 0.1f);
            */
            GL.glColor4d(0, 0, 1, 0.5);
            GL.glVertex3d(0.5, 0.5, 0.01f);
            GL.glVertex3d(0.5, 9.5, 0.01f);
            GL.glVertex3d(9.5, 9.5, 0.01f);
            GL.glVertex3d(9.5, 0.5, 0.01f);
            GL.glEnd();
            GL.glPopMatrix();
        }


        public float[] pos = new float[4];
        public int intOptionB = 1;

        public float[] ScrollValue = new float[14];
        public float zShift = 0.0f;
        public float yShift = 0.0f;
        public float xShift = 0.0f;
        public float zAngle = 0.0f;
        public float yAngle = 0.0f;
        public float xAngle = 0.0f;
        public int intOptionC = 0;
        public int shoulderAngle = 20;
        public int mirrorAngle = 70;
        
        public int sin_index = 0;
        double[] AccumulatedRotationsTraslations = new double[16];

        public void Draw()
        {

            //Shadows
            pos[0] = ScrollValue[10];
            pos[1] = ScrollValue[11];
            pos[2] = ScrollValue[12];
            pos[3] = 1.0f;
            //Shadows

            if (m_uint_DC == 0 || m_uint_RC == 0)
                return;
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //                                                           see InitializeGL also
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            GL.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

            GL.glLoadIdentity();

            //Handeling of translate rotate - mathematically correct
            double[] ModelVievMatrixBeforeSpecificTransforms = new double[16];
            double[] CurrentRotationTraslation = new double[16];

            GLU.gluLookAt(ScrollValue[0], ScrollValue[1], ScrollValue[2],
                       ScrollValue[3], ScrollValue[4], ScrollValue[5],
                       ScrollValue[6], ScrollValue[7], ScrollValue[8]);
            GL.glTranslatef(0.0f, 0.0f, -1.0f);
            GL.glTranslatef(0.0f, 0.0f, -10.0f);

            //save current ModelView Matrix values
            //in ModelVievMatrixBeforeSpecificTransforms array
            //ModelView Matrix ========>>>>>> ModelVievMatrixBeforeSpecificTransforms
            GL.glGetDoublev(GL.GL_MODELVIEW_MATRIX, ModelVievMatrixBeforeSpecificTransforms);
            //ModelView Matrix was saved, so
            GL.glLoadIdentity(); // make it identity matrix

            //make transformation in accordance to KeyCode
            float delta;
            if (intOptionC != 0)
            {
                delta = 5.0f * Math.Abs(intOptionC) / intOptionC; // signed 5

                switch (Math.Abs(intOptionC))
                {
                    case 1:
                        GL.glRotatef(delta, 1, 0, 0);
                        break;
                    case 2:
                        GL.glRotatef(delta, 0, 1, 0);
                        break;
                    case 3:
                        GL.glRotatef(delta, 0, 0, 1);
                        break;
                    case 4:
                        GL.glTranslatef(delta / 20, 0, 0);
                        break;
                    case 5:
                        GL.glTranslatef(0, delta / 20, 0);
                        break;
                    case 6:
                        GL.glTranslatef(0, 0, delta / 20);
                        break;
                }
            }
            //as result - the ModelView Matrix now is pure representation
            //of KeyCode transform and only it !!!

            //save current ModelView Matrix values
            //in CurrentRotationTraslation array
            //ModelView Matrix =======>>>>>>> CurrentRotationTraslation
            GL.glGetDoublev(GL.GL_MODELVIEW_MATRIX, CurrentRotationTraslation);

            //The GL.glLoadMatrix function replaces the current matrix with
            //the one specified in its argument.
            //The current matrix is the
            //projection matrix, modelview matrix, or texture matrix,
            //determined by the current matrix mode (now is ModelView mode)
            GL.glLoadMatrixd(AccumulatedRotationsTraslations); //Global Matrix

            //The GL.glMultMatrix function multiplies the current matrix by
            //the one specified in its argument.
            //That is, if M is the current matrix and T is the matrix passed to
            //GL.glMultMatrix, then M is replaced with M • T
            GL.glMultMatrixd(CurrentRotationTraslation);

            //save the matrix product in AccumulatedRotationsTraslations
            GL.glGetDoublev(GL.GL_MODELVIEW_MATRIX, AccumulatedRotationsTraslations);

            //replace ModelViev Matrix with stored ModelVievMatrixBeforeSpecificTransforms
            GL.glLoadMatrixd(ModelVievMatrixBeforeSpecificTransforms);
            //multiply it by KeyCode defined AccumulatedRotationsTraslations matrix
            GL.glMultMatrixd(AccumulatedRotationsTraslations);

            //end of - Handeling of translate rotate mathematically correct
            
            //Animation Values
            intOptionB += 10;   
            intOptionC += 2;    //dancer rotation
            sin_index++;
                                //for arms animation
            shoulderAngle = (int)(45 + 45*Math.Sin((2 * Math.PI) / 100 * sin_index));

            //Settings for drawing semi transparent stuff
            GL.glEnable(GL.GL_BLEND);
            GL.glBlendFunc(GL.GL_SRC_ALPHA, GL.GL_ONE_MINUS_SRC_ALPHA);

            //making a stencil for the mirror
            GL.glEnable(GL.GL_STENCIL_TEST);
            GL.glStencilOp(GL.GL_REPLACE, GL.GL_REPLACE, GL.GL_REPLACE);
            GL.glStencilFunc(GL.GL_ALWAYS, 1, 0xFFFFFFFF);
            GL.glColorMask((byte)GL.GL_FALSE, (byte)GL.GL_FALSE, (byte)GL.GL_FALSE, (byte)GL.GL_FALSE);
            GL.glDisable(GL.GL_DEPTH_TEST); //draw no matter what
            //not really draw. just makeing a hole in the stencil
            DrawMirror();

            //restore regular settings
            GL.glColorMask((byte)GL.GL_TRUE, (byte)GL.GL_TRUE, (byte)GL.GL_TRUE, (byte)GL.GL_TRUE);
            GL.glEnable(GL.GL_DEPTH_TEST);

            //setting stencil test (anything outside is clipped)
            GL.glStencilFunc(GL.GL_EQUAL, 1, 0xFFFFFFFF);
            GL.glStencilOp(GL.GL_KEEP, GL.GL_KEEP, GL.GL_KEEP);
            GL.glEnable(GL.GL_STENCIL_TEST);

            //draw reflected scene
            GL.glPushMatrix();
            GL.glTranslated(0f, 10f, 5f);   //moving into the mirror
            GL.glRotated(mirrorAngle-90, 1, 0, 0);    //rotating according to mirror angle
            GL.glTranslated(0f, 10f, -5f);   //moving into the mirror
            GL.glScalef(1, -1, 1);
            DrawChest();
            DrawTheWomanInRed(false);
            GL.glPopMatrix();

            GL.glDisable(GL.GL_STENCIL_TEST); //no need for the stencil anymore

            //draw the mirror no matter what
            //no need to disable depth mask / depth test
            //since reflection is far from mirror
            //also. if we disable. the mirror will be
            //overwritten by the chest lid in the z buffer

            //GL.glDepthMask((byte)GL.GL_FALSE);
            //GL.glDisable(GL.GL_DEPTH_TEST);
            DrawMirror();
            //GL.glEnable(GL.GL_DEPTH_TEST);
            //GL.glDepthMask((byte)GL.GL_TRUE);

            GL.glLightfv(GL.GL_LIGHT0, GL.GL_POSITION, pos);
            GL.glEnable(GL.GL_LIGHTING);
            //NOW draw the scene
            //Draw Light Source
            GL.glDisable(GL.GL_LIGHTING);
            GL.glTranslatef(pos[0], pos[1], pos[2]);
            //Yellow Light source
            GL.glColor3f(1, 1, 0);
            GLUT.glutSolidSphere(0.5, 8, 8);
            GL.glTranslatef(-pos[0], -pos[1], -pos[2]);
            GL.glEnable(GL.GL_LIGHTING);

            DrawChest();
            DrawChestLid();
            DrawTheWomanInRed(false);

            //making a stencil for the shadow
            GL.glEnable(GL.GL_STENCIL_TEST);
            GL.glStencilOp(GL.GL_REPLACE, GL.GL_REPLACE, GL.GL_REPLACE);
            GL.glStencilFunc(GL.GL_ALWAYS, 1, 0xFFFFFFFF);
            GL.glColorMask((byte)GL.GL_FALSE, (byte)GL.GL_FALSE, (byte)GL.GL_FALSE, (byte)GL.GL_FALSE);
            GL.glDisable(GL.GL_DEPTH_TEST); //draw no matter what
            //making a hole in the stencil
            DrawHoleInAPit(); //draws only the top of the chest

            //restore regular settings
            GL.glColorMask((byte)GL.GL_TRUE, (byte)GL.GL_TRUE, (byte)GL.GL_TRUE, (byte)GL.GL_TRUE);
            GL.glEnable(GL.GL_DEPTH_TEST);

            //setting stencil test (anything outside is clipped)
            GL.glStencilFunc(GL.GL_EQUAL, 1, 0xFFFFFFFF);
            GL.glStencilOp(GL.GL_KEEP, GL.GL_KEEP, GL.GL_KEEP);
            GL.glEnable(GL.GL_STENCIL_TEST);
            
            //draw Shadow
            GL.glPushMatrix();
            MakeShadowMatrix(ground); //results in cubeXform - shadow matrix 
            GL.glMultMatrixf(cubeXform); //flattning everything against chest top plain
            DrawTheWomanInRed(true); //draws dancer in BLACK
            GL.glPopMatrix();
            GL.glDisable(GL.GL_LIGHTING);
            
            GL.glFlush();

            WGL.wglSwapBuffers(m_uint_DC);

        }
        float[,] ground = new float[3, 3];//{ { 1, 1, -0.5 }, { 0, 1, -0.5 }, { 1, 0, -0.5 } };
        
        const int x = 0;
        const int y = 1;
        const int z = 2;
        void calcNormal(float[,] v, float[] outp)
        {
            float[] v1 = new float[3];
            float[] v2 = new float[3];

            // Calculate two vectors from the three points
            v1[x] = v[0, x] - v[1, x];
            v1[y] = v[0, y] - v[1, y];
            v1[z] = v[0, z] - v[1, z];

            v2[x] = v[1, x] - v[2, x];
            v2[y] = v[1, y] - v[2, y];
            v2[z] = v[1, z] - v[2, z];

            // Take the cross product of the two vectors to get
            // the normal vector which will be stored in out
            outp[x] = v1[y] * v2[z] - v1[z] * v2[y];
            outp[y] = v1[z] * v2[x] - v1[x] * v2[z];
            outp[z] = v1[x] * v2[y] - v1[y] * v2[x];

            // Normalize the vector (shorten length to one)
            ReduceToUnit(outp);
        }
        void ReduceToUnit(float[] vector)
        {
            float length;

            // Calculate the length of the vector		
            length = (float)Math.Sqrt((vector[0] * vector[0]) +
                                (vector[1] * vector[1]) +
                                (vector[2] * vector[2]));

            // Keep the program from blowing up by providing an exceptable
            // value for vectors that may calculated too close to zero.
            if (length == 0.0f)
                length = 1.0f;

            // Dividing each element by the length will result in a
            // unit normal vector.
            vector[0] /= length;
            vector[1] /= length;
            vector[2] /= length;
        }

        float[] cubeXform = new float[16];
        // Creates a shadow projection matrix out of the plane equation
        // coefficients and the position of the light. The return value is stored
        // in cubeXform[,]
        void MakeShadowMatrix(float[,] points)
        {
            float[] planeCoeff = new float[4];
            float dot;

            // Find the plane equation coefficients
            // Find the first three coefficients the same way we
            // find a normal.
            calcNormal(points, planeCoeff);

            // Find the last coefficient by back substitutions
            planeCoeff[3] = -(
                (planeCoeff[0] * points[2, 0]) + (planeCoeff[1] * points[2, 1]) +
                (planeCoeff[2] * points[2, 2]));


            // Dot product of plane and light position
            dot = planeCoeff[0] * pos[0] +
                    planeCoeff[1] * pos[1] +
                    planeCoeff[2] * pos[2] +
                    planeCoeff[3];

            // Now do the projection
            // First column
            cubeXform[0] = dot - pos[0] * planeCoeff[0];
            cubeXform[4] = 0.0f - pos[0] * planeCoeff[1];
            cubeXform[8] = 0.0f - pos[0] * planeCoeff[2];
            cubeXform[12] = 0.0f - pos[0] * planeCoeff[3];

            // Second column
            cubeXform[1] = 0.0f - pos[1] * planeCoeff[0];
            cubeXform[5] = dot - pos[1] * planeCoeff[1];
            cubeXform[9] = 0.0f - pos[1] * planeCoeff[2];
            cubeXform[13] = 0.0f - pos[1] * planeCoeff[3];

            // Third Column
            cubeXform[2] = 0.0f - pos[2] * planeCoeff[0];
            cubeXform[6] = 0.0f - pos[2] * planeCoeff[1];
            cubeXform[10] = dot - pos[2] * planeCoeff[2];
            cubeXform[14] = 0.0f - pos[2] * planeCoeff[3];

            // Fourth Column
            cubeXform[3] = 0.0f - pos[3] * planeCoeff[0];
            cubeXform[7] = 0.0f - pos[3] * planeCoeff[1];
            cubeXform[11] = 0.0f - pos[3] * planeCoeff[2];
            cubeXform[15] = dot - pos[3] * planeCoeff[3];
        }
        void pre_MapSphereTexture(int index)
        {
            GL.glBindTexture(GL.GL_TEXTURE_2D,Textures[index]);
            GL.glEnable(GL.GL_TEXTURE_2D);
            GL.glEnable(GL.GL_TEXTURE_GEN_S);
            GL.glEnable(GL.GL_TEXTURE_GEN_T);
            GL.glTexGeni(GL.GL_S,GL.GL_TEXTURE_GEN_MODE,(int)GL.GL_SPHERE_MAP);
            GL.glTexGeni(GL.GL_T, GL.GL_TEXTURE_GEN_MODE, (int)GL.GL_SPHERE_MAP);
        }
        void pre_MapCylinderTexture(int index)
        {
            //GL.glBindTexture(GL.GL_TEXTURE_2D, Textures[index]);
            //GL.glEnable(GL.GL_TEXTURE_2D);
            //GL.glEnable(GL.GL_TEXTURE_GEN_S);
            //GL.glEnable(GL.GL_TEXTURE_GEN_T);
            ////GL.glTexGeni(GL.GL_S, GL.GL_TEXTURE_GEN_MODE, (int)GL.GL_OBJECT_LINEAR);
            //GL.glTexGeni(GL.GL_S, GL.GL_TEXTURE_GEN_MODE, (int)GL.GL_EYE_LINEAR);
            ////GL.glTexGeni(GL.GL_T, GL.GL_TEXTURE_GEN_MODE, (int)GL.GL_OBJECT_LINEAR);
            //GL.glTexGeni(GL.GL_T, GL.GL_TEXTURE_GEN_MODE, (int)GL.GL_EYE_LINEAR);
            GL.glBindTexture(GL.GL_TEXTURE_2D, Textures[index]);
            GL.glEnable(GL.GL_TEXTURE_2D);
            GLU.gluQuadricTexture(obj, 1);
        }
        void end_MapTexture()
        {
            GL.glDisable(GL.GL_TEXTURE_GEN_S);
            GL.glDisable(GL.GL_TEXTURE_GEN_T);
            GL.glDisable(GL.GL_TEXTURE_2D);
        }

        protected virtual void InitializeGL()
        {
            m_uint_HWND = (uint)p.Handle.ToInt32();
            m_uint_DC = WGL.GetDC(m_uint_HWND);

            // Not doing the following WGL.wglSwapBuffers() on the DC will
            // result in a failure to subsequently create the RC.
            WGL.wglSwapBuffers(m_uint_DC);

            WGL.PIXELFORMATDESCRIPTOR pfd = new WGL.PIXELFORMATDESCRIPTOR();
            WGL.ZeroPixelDescriptor(ref pfd);
            pfd.nVersion = 1;
            pfd.dwFlags = (WGL.PFD_DRAW_TO_WINDOW | WGL.PFD_SUPPORT_OPENGL | WGL.PFD_DOUBLEBUFFER);
            pfd.iPixelType = (byte)(WGL.PFD_TYPE_RGBA);
            pfd.cColorBits = 32;
            pfd.cDepthBits = 32;
            pfd.iLayerType = (byte)(WGL.PFD_MAIN_PLANE);

            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            //for Stencil support 

            pfd.cStencilBits = 32;

            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            int pixelFormatIndex = 0;
            pixelFormatIndex = WGL.ChoosePixelFormat(m_uint_DC, ref pfd);
            if (pixelFormatIndex == 0)
            {
                MessageBox.Show("Unable to retrieve pixel format");
                return;
            }

            if (WGL.SetPixelFormat(m_uint_DC, pixelFormatIndex, ref pfd) == 0)
            {
                MessageBox.Show("Unable to set pixel format");
                return;
            }
            //Create rendering context
            m_uint_RC = WGL.wglCreateContext(m_uint_DC);
            if (m_uint_RC == 0)
            {
                MessageBox.Show("Unable to get rendering context");
                return;
            }
            if (WGL.wglMakeCurrent(m_uint_DC, m_uint_RC) == 0)
            {
                MessageBox.Show("Unable to make rendering context current");
                return;
            }


            initRenderingGL();
        }

        public void OnResize()
        {
            Width = p.Width;
            Height = p.Height;
            GL.glViewport(0, 0, Width, Height);
            Draw();
        }

        protected virtual void initRenderingGL()
        {
            if (m_uint_DC == 0 || m_uint_RC == 0)
                return;
            if (this.Width == 0 || this.Height == 0)
                return;

            GL.glShadeModel(GL.GL_SMOOTH);
            GL.glClearColor(0.0f, 0.0f, 0.0f, 0.5f);
            GL.glClearDepth(1.0f);


            GL.glEnable(GL.GL_LIGHT0);
            GL.glEnable(GL.GL_COLOR_MATERIAL);
            GL.glColorMaterial(GL.GL_FRONT_AND_BACK, GL.GL_AMBIENT_AND_DIFFUSE);

            GL.glEnable(GL.GL_DEPTH_TEST);
            GL.glDepthFunc(GL.GL_LEQUAL);
            GL.glHint(GL.GL_PERSPECTIVE_CORRECTION_Hint, GL.GL_NICEST);


            GL.glViewport(0, 0, this.Width, this.Height);
            GL.glMatrixMode(GL.GL_PROJECTION);
            GL.glLoadIdentity();

            //! TEXTURE 1a 
            GL.glEnable(GL.GL_COLOR_MATERIAL);
            float[] emis = { 0.3f, 0.3f, 0.3f, 1 };
            GL.glMaterialfv(GL.GL_FRONT_AND_BACK, GL.GL_EMISSION, emis);
            //! TEXTURE 1a 


            //nice 3D
            GL.glShadeModel(GL.GL_SMOOTH);
            GLU.gluPerspective(45.0, 1.0, 0.4, 100.0);

            GL.glMatrixMode(GL.GL_MODELVIEW);
            GL.glLoadIdentity();

            GenerateTextures();

            //save the current MODELVIEW Matrix (now it is Identity)
            GL.glGetDoublev(GL.GL_MODELVIEW_MATRIX, AccumulatedRotationsTraslations);
        }

        //! TEXTURE b
        public uint[] Textures = new uint[10];

        void GenerateTextures()
        {
            GL.glBlendFunc(GL.GL_SRC_ALPHA, GL.GL_ONE_MINUS_SRC_ALPHA);
            string[] imagesName ={ "chestbg.jpg", "chestbg2.jpg", "shoe.jpg", "leg.jpg", "tutu.png", "shirt.PNG", "face.jpg" };
            GL.glGenTextures(imagesName.Length, Textures);
            for (int i = 0; i < imagesName.Length; i++)
            {
                Bitmap image = new Bitmap(imagesName[i]);
                image.RotateFlip(RotateFlipType.RotateNoneFlipY); //Y axis in Windows is directed downwards, while in OpenGL-upwards
                System.Drawing.Imaging.BitmapData bitmapdata;
                Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);

                bitmapdata = image.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

                GL.glBindTexture(GL.GL_TEXTURE_2D, Textures[i]);
                //2D for XYZ
                GL.glTexImage2D(GL.GL_TEXTURE_2D, 0, (int)GL.GL_RGB8, image.Width, image.Height,
                                                              0, GL.GL_BGR_EXT, GL.GL_UNSIGNED_byte, bitmapdata.Scan0);
                GL.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_LINEAR);
                GL.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_LINEAR);

                image.UnlockBits(bitmapdata);
                image.Dispose();
            }
        }
    }
}


