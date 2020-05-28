#include <stdio.h>
#include <assert.h>
#include <stdlib.h>			
#include <glaux.h>				
#include <glut.h>
#include <math.h>
#include <iostream>
#include "main.h"

using namespace std;

#define	MAX_PARTICLES	10000		

GLuint g_mainWnd;
GLuint g_nWinWidth  = G308_WIN_WIDTH;
GLuint g_nWinHeight = G308_WIN_HEIGHT;		
GLuint i;						
GLuint texture[1];					

static GLfloat white[3] =	{1.0f, 1.0f, 1.0f};
static GLfloat blue[3] =	{0.5f, 0.0f, 1.0f};
static GLfloat yellow[3] =	{1.0f, 1.0f, 0.0f};
static GLfloat orange[3] =	{1.0f, 0.5f, 0.0f};
static GLfloat red[3] =		{1.0f, 0.1f, 0.0f};


int windowWidth = 800,	windowHeight = 800;
float xspeed,			yspeed,			zoom = -40.0f;
float posX = 0.0f,		posY = -5.0f,	posZ = 0.0f;
float gravX = 0.0f,		gravY = 0.0f,	gravZ = 0.0f;
float camX = 0.0f,		camY = 2.5f,	camZ = 50.0f;

typedef struct						
{
	bool	active;					
	float	life;					
	float	fade;					
	float	r;						
	float	g;						
	float	b;						
	float	x;						
	float	y;						
	float	z;						
	float	xi;						
	float	yi;						
	float	zi;						
	float	xg;						
	float	yg;						
	float	zg;						
} particle_t;							

particle_t particles[MAX_PARTICLES];	

AUX_RGBImageRec *LoadBMP(char *Filename)				
{
        FILE *File=NULL;								
        if (!Filename)									
        {
                return NULL;							
        }
        File=fopen(Filename,"r");						
        if (File)										
        {
			fclose(File);								
			return auxDIBImageLoad(Filename);			
        }
        return NULL;									
}

int LoadGLTextures()									
{
        int Status=FALSE;								
        AUX_RGBImageRec *TextureImage[1];				
        memset(TextureImage,0,sizeof(void *)*1);		

        if (TextureImage[0]=LoadBMP("img/Particle.bmp"))	
        {
			Status=TRUE;								
			glGenTextures(1, &texture[0]);				

			glBindTexture(GL_TEXTURE_2D, texture[0]);
			glTexParameteri(GL_TEXTURE_2D,GL_TEXTURE_MAG_FILTER,GL_LINEAR);
			glTexParameteri(GL_TEXTURE_2D,GL_TEXTURE_MIN_FILTER,GL_LINEAR);
			glTexImage2D(GL_TEXTURE_2D, 0, 3, TextureImage[0]->sizeX, TextureImage[0]->sizeY, 0, GL_RGB, GL_UNSIGNED_BYTE, TextureImage[0]->data);
        }

        if (TextureImage[0])							
		{
			if (TextureImage[0]->data)					
			{
				free(TextureImage[0]->data);			
			}
			free(TextureImage[0]);						
		}
        return Status;									
}

void InitGL()										
{
	LoadGLTextures();								

	glShadeModel(GL_SMOOTH);							
	glClearColor(0.0f,0.0f,0.0f,0.0f);					
	glClearDepth(1.0f);									

	glDisable(GL_DEPTH_TEST);							

	glEnable(GL_BLEND);									
	glBlendFunc(GL_SRC_ALPHA,GL_ONE);					
	glHint(GL_PERSPECTIVE_CORRECTION_HINT,GL_NICEST);	
	glHint(GL_POINT_SMOOTH_HINT,GL_NICEST);				
	glEnable(GL_TEXTURE_2D);							
	glBindTexture(GL_TEXTURE_2D,texture[0]);			

	for (i=0;i<MAX_PARTICLES;i++)				
	{
		particles[i].active=true;								
		particles[i].life=1.0f;								
		particles[i].fade=float(rand()%100)/1000.0f+0.003f;	
		particles[i].r=white[0];	
		particles[i].g=white[1];	
		particles[i].b=white[2];	
		particles[i].xi=float((rand()%50)-25.0f)*10.0f;		
		particles[i].yi=float((rand()%50)-25.0f)*10.0f;		
		particles[i].zi=float((rand()%50)-25.0f)*10.0f;		
		particles[i].xg=0.0f;									
		particles[i].yg=0.8f;									
		particles[i].zg=0.0f;									
	}
}


void G308_Reshape(int w, int h)
{
	if (h == 0) h = 1;

	g_nWinWidth = w;
	g_nWinHeight = h;
    
    glViewport(0, 0, g_nWinWidth, g_nWinHeight);
}


void SetLight()
{
	float direction[]	  = {0.0f, 0.0f, 1.0f, 0.0f};
	float diffintensity[] = {0.7f, 0.7f, 0.7f, 1.0f};
	float ambient[]       = {0.2f, 0.2f, 0.2f, 1.0f};

	glLightfv(GL_LIGHT0, GL_POSITION, direction);
	glLightfv(GL_LIGHT0, GL_DIFFUSE,  diffintensity);
	glLightfv(GL_LIGHT0, GL_AMBIENT,  ambient);	
	
	
	glEnable(GL_LIGHT0);
}


void SetCamera()
{
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	gluPerspective(G308_FOVY, (double) g_nWinWidth / (double) g_nWinHeight, G308_ZNEAR_3D, G308_ZFAR_3D);
	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();

	gluLookAt(camX, camY, camZ, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0); 

}

void DrawGLScene()										
{
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);		
	glLoadIdentity();										
	for (i=0;i<MAX_PARTICLES;i++)					
	{
		if (particles[i].active)							
		{	
			
			float x=particles[i].x;						
			float y=particles[i].y;						
			float z=particles[i].z+zoom;					

			
			glColor4f(particles[i].r,particles[i].g,particles[i].b,particles[i].life);

			glBegin(GL_TRIANGLE_STRIP);						
			    glTexCoord2d(1,1); glVertex3f(x+0.5f,y+0.5f,z); 
				glTexCoord2d(0,1); glVertex3f(x-0.5f,y+0.5f,z); 
				glTexCoord2d(1,0); glVertex3f(x+0.5f,y-0.5f,z); 
				glTexCoord2d(0,0); glVertex3f(x-0.5f,y-0.5f,z); 
			glEnd();										

			particles[i].x+=particles[i].xi/(750);
			particles[i].y+=particles[i].yi/(1000);
			particles[i].z+=particles[i].zi/(750);
			
			if((particles[i].x>posX)&&(particles[i].y>(0.1+posY))){
				particles[i].xg=-0.3f;
			} else if((particles[i].x<posX)&&(particles[i].y>(0.1+posY))){
				particles[i].xg=0.3f;
			} else {
				particles[i].xg=0.0f;
			}
			
			particles[i].xi+=(particles[i].xg + gravX);			
			particles[i].yi+=(particles[i].yg + gravY);			
			particles[i].zi+=(particles[i].zg + gravZ);			
			particles[i].life-=particles[i].fade;		
						
			if (particles[i].life<0.0f)					
			{
				particles[i].life=1.0f;					
				particles[i].fade=float(rand()%100)/1000.0f+0.003f;	
				particles[i].x=posX;						
				particles[i].y=posY;						
				particles[i].z=posZ;						
				particles[i].xi=xspeed+float((rand()%60)-30.0f);	
				particles[i].yi=yspeed+float((rand()%60)-30.0f);	
				particles[i].zi=float((rand()%60)-30.0f);	
				particles[i].r=white[0];			
				particles[i].g=white[1];			
				particles[i].b=white[2];			
			}
			else if (particles[i].life<0.4f)					
			{
				particles[i].r=red[0];			
				particles[i].g=red[1];			
				particles[i].b=red[2];
			}
			else if (particles[i].life<0.6f)					
			{
				particles[i].r=orange[0];			
				particles[i].g=orange[1];			
				particles[i].b=orange[2];
			}
			else if (particles[i].life<0.75f)				
			{
				particles[i].r=yellow[0];			
				particles[i].g=yellow[1];			
				particles[i].b=yellow[2];
			}
			else if (particles[i].life<0.85f)					
			{
				particles[i].r=blue[0];			
				particles[i].g=blue[1];			
				particles[i].b=blue[2];
			}
		}
    }
	glutPostRedisplay();
	glutSwapBuffers();
}

int main(int argc, char** argv)
{
	glutInit(&argc, argv);
    glutInitDisplayMode(GLUT_DOUBLE | GLUT_RGBA | GLUT_DEPTH);
    glutInitWindowSize(g_nWinWidth, g_nWinHeight);
    g_mainWnd = glutCreateWindow("Fire Particles");

	glutDisplayFunc(DrawGLScene);
    glutReshapeFunc(G308_Reshape);

	InitGL();

	SetLight();
	SetCamera();	

	glutMainLoop();

    return 0;
}
