#include <signal.h>
#include <string.h>
#include <stdio.h>
#include <stdarg.h>
#include <time.h>
#include <stdlib.h>
#include <windows.h>

char *gpTraceFile = "C:\\temp\\trace.log";
int gTrace = 1;

void Trace(const LPWSTR format, ...)
{
	if (!gTrace) return;

	FILE *pf = stderr;

	if (gpTraceFile != NULL)
	{
		if (fopen_s(&pf, gpTraceFile, "a") != 0)
		{
			fprintf(stderr, "WARNING: Failed to open trace file '%s' for writing!\n", gpTraceFile);
			return;
		}
	}

	va_list ap;
	va_start(ap, format);
	vfwprintf(pf, format, ap);
	va_end(ap);

	fprintf(pf, "\n");

	if (gpTraceFile != NULL) fclose(pf);
}
