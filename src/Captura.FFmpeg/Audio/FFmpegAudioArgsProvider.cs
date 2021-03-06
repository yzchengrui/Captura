﻿namespace Captura.Models
{
    /// <summary>
    /// Provides FFmpeg Audio encoding Command-line args.
    /// </summary>
    delegate void FFmpegAudioArgsProvider(int AudioQuality, FFmpegOutputArgs OutputArgs);
}
